using AutoMapper;
using Core;
using Core.Repositories;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Configuration;
using System.Diagnostics;

namespace Services
{
    public class PanjService : BaseConfiguration
    {
        private IUnitOfWork _unitOfWork;
        private readonly IIgracRepository _igracRepository;
        private readonly IIgraRepository _igraRepository;
        private readonly IKorisnikRepository _korisnikRepository;
        private readonly IPreprekeRepository _preprekeRepository;
        private readonly ISuciRepository _suciRepository;
        private readonly ITimRepository _timRepository;
        private readonly IMecRepository _mecRepository;
        private readonly ITimPripadnostRepository _timPripadnostRepository;

        public PanjService(IUnitOfWork unitOfWork, IMecRepository mecRepository, ITimRepository timRepository, ITimPripadnostRepository timPripadnostRepository,
                                    ISuciRepository suciRepository, IPreprekeRepository preprekeRepository, IKorisnikRepository korisnikRepository,
                                    IIgraRepository igraRepository, IIgracRepository igracRepository)
        {
            _unitOfWork = unitOfWork;
            _igracRepository = igracRepository;
            _igraRepository = igraRepository;
            _korisnikRepository = korisnikRepository;
            _preprekeRepository = preprekeRepository;
            _suciRepository = suciRepository;
            _timRepository = timRepository;
            _mecRepository = mecRepository;
            _timPripadnostRepository = timPripadnostRepository;
        }

        public IEnumerable<Tim> GetTimoviUMecu(int mid)
        {
            return _mecRepository.GetTimoviUMecu(mid);
        }

        public Igra GetIgra(int iid)
        {
            return _unitOfWork.Igra.Where(i => i.Id == iid).SingleOrDefault();
        }

        public Mec GetMec(int mid)
        {
            return _unitOfWork.Mec.Find(mid);
        }

        public ScoreDTO GetUserScores(string faceid)
        {
            return new ScoreDTO { wins=_unitOfWork.Igrac.Select(i => i.Pobjede).FirstOrDefault(),loses= _unitOfWork.Igrac.Select(i => i.Porazi).FirstOrDefault() };
        }

        public IEnumerable<Korisnik> GetIgracByMec(int mid)
        {
            var igraci1 = from m in _unitOfWork.Mec
                         join t in _unitOfWork.Tim on m.PrviTimId equals t.Id
                         join tp in _unitOfWork.TimPripadnost on t.Id equals tp.TimId
                         join ig in _unitOfWork.Igrac on tp.IgracId equals ig.Id
                         join ko in _unitOfWork.Korisnik on ig.KorisnikId equals ko.Id
                         where m.Id == mid
                         select ko;

            var igraci2 = from m in _unitOfWork.Mec
                          join t in _unitOfWork.Tim on m.DrugiTimId equals t.Id
                          join tp in _unitOfWork.TimPripadnost on t.Id equals tp.TimId
                          join ig in _unitOfWork.Igrac on tp.IgracId equals ig.Id
                          join ko in _unitOfWork.Korisnik on ig.KorisnikId equals ko.Id
                          where m.Id == mid
                          select ko;

            return igraci1.Concat(igraci2);
        }

        public Igra GetAktivnaIgra(int mid)
        {
            return _unitOfWork.Igra.Where(i => i.MecId == mid).SingleOrDefault();
        }

        public void DodajUTim(string faceID, int TID)
        {
            int IID = (from i in _unitOfWork.Igrac
                      join k in _unitOfWork.Korisnik on i.KorisnikId equals k.Id
                      where k.FaceId == faceID
                      select i.Id).SingleOrDefault();

            TimPripadnost tp = new TimPripadnost { IgracId=IID, TimId=TID };

            _timPripadnostRepository.Add(tp);
            _unitOfWork.Commit();
        }

        public IEnumerable<MecDTO> GetAktivni()
        {
            var mecevi = _mecRepository.GetAktivni();
            var meceviDTO = Mapper.Map<IEnumerable<MecDTO>>(mecevi);

            return meceviDTO;
        }

        public int AddMec(NewMecDTO newMecDTO)
        {
            MecDTO mecDTO = Mapper.Map<MecDTO>(newMecDTO);

            Tim tim1DTO = new Tim { Ime = newMecDTO.tim1 };
            Tim tim2DTO = new Tim { Ime = newMecDTO.tim2 };

            Mec mec = Mapper.Map<Mec>(mecDTO);

            try
            {

                Tim tim1 = _timRepository.Add(tim1DTO);
                Tim tim2 = _timRepository.Add(tim2DTO);
                _unitOfWork.Commit();

                mec.PrviTimId = tim1.Id;
                mec.DrugiTimId = tim2.Id;

                Mec addedMec = _mecRepository.Add(mec);

                _unitOfWork.Commit();

                return addedMec.Id;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                _unitOfWork.RollbackChanges();
                return -1;
            }
        }

        public void UpdateIgrac(IgracDTO igracDTO)
        {
            try
            {
                Igrac oldIgrac = _igracRepository.GetByKorisnikId(igracDTO.korisnikID);

                Mapper.Map<IgracDTO,Igrac>(igracDTO,oldIgrac);

                _igracRepository.Update(oldIgrac);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                _unitOfWork.RollbackChanges();
            }
        }

        public int AddIgra(newIgraDTO newIgraDTO)
        {

            IgraDTO igraDTO = Mapper.Map<IgraDTO>(newIgraDTO);

            Igra igra = Mapper.Map<Igra>(igraDTO);

            try
            {
                Igra addedIgra = _igraRepository.Add(igra);
                _unitOfWork.Commit();

                foreach (Prepreke p in newIgraDTO.prepreke)
                {
                    p.IgraId = addedIgra.Id;
                    _preprekeRepository.Add(p);
                }

                _unitOfWork.Commit();
                return addedIgra.Id;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                _unitOfWork.RollbackChanges();
                return -1;
            }
        }

        public void SetAktivIgra(int iid)
        {
            try
            {
                Igra oldIgra = _igraRepository.Get(iid);

                oldIgra.Aktivna = !oldIgra.Aktivna;

                _igraRepository.Update(oldIgra);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                _unitOfWork.RollbackChanges();
            }
        }
    }
}
