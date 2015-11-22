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
