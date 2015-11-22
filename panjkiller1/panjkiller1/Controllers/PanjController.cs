using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using Services;
using Core;
using Repositories;
using Newtonsoft.Json;
using System.Diagnostics;
using AutoMapper;

namespace panjkiller1.Controllers
{
    public class PanjController : ApiController
    {
        private PanjService _panjService;

        public PanjController()
        {
            var db = new bazaContext();
            var uow = new UnitOfWork(db);
            var mecRepository = new MecRepository(uow);
            var igracRepository = new IgracRepository(uow);
            var igraRepository = new IgraRepository(uow);
            var korisnikRepository = new KorisnikRepository(uow);
            var preprekeRepository = new PreprekeRepository(uow);
            var suciRepository = new SuciRepository(uow);
            var timPripadnostRepository = new TimPripadnostRepository(uow);
            var timRepository = new TimRepository(uow);
            var vrstaPreprekeRepository = new VrstaPreprekeRepository(uow);
            _panjService = new PanjService(uow, mecRepository, timRepository, timPripadnostRepository, suciRepository, preprekeRepository, korisnikRepository, igraRepository, igracRepository);
        }


        #region gets

        [HttpGet]
        [Route("api/panj/igra/toggleAktiv/{iid}")]
        public void SetAktivIgra(int iid)
        {
            try
            {
                _panjService.SetAktivIgra(iid);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                Exception up = new HttpResponseException(HttpStatusCode.BadRequest);
                throw up;
            }
        }

        [Route("api/panj/mec/aktivni")]
        public IEnumerable<MecDTO> GetAktivni()
        {
            return _panjService.GetAktivni();
        }

        [Route("api/panj/mec/timovi/{mid}")]
        public IEnumerable<Tim> GetTimoviUMecu(int mid)
        {
            return _panjService.GetTimoviUMecu(mid);
        }

        [Route("api/panj/mec/{mid}")]
        public Mec GetMec(int mid)
        {
            return _panjService.GetMec(mid);
        }

        [Route("api/panj/igra/{iid}")]
        public Igra GetIgra(int iid)
        {
            return _panjService.GetIgra(iid);
        }

        [Route("api/panj/userscore/{uid}")]
        public ScoreDTO GetUserScore(string faceid)
        {
            return _panjService.GetUserScores(faceid);
        }

        [Route("api/panj/korisnici/mec/{mid}")]
        public IEnumerable<Korisnik> GetIgracFromMec(int mid)
        {
            return _panjService.GetIgracByMec(mid);
        }

        // GET /api/panj/igrac?faceID={faceID}&timID={timID}
        [Route("api/panj/igrac/dodaj/")]
        public void DodajUTim()
        {
            var req = Request.GetQueryNameValuePairs();
            string faceID = req.Where(id => id.Key == "faceID")
                                            .Select(q => q.Value).FirstOrDefault();
            int TID = -1;
            Int32.TryParse(Request.GetQueryNameValuePairs()
                                            .Where(id => id.Key == "timID")
                                            .Select(q => q.Value).FirstOrDefault(),
                                          out TID);
            _panjService.DodajUTim(faceID, TID);
        }

        [Route("api/panj/mec/igra/{mid}")]
        public Igra GetAktivnaIgra(int mid)
        {
            return _panjService.GetAktivnaIgra(mid);
        }

        #endregion

        [HttpPost]
        [Route("api/panj/mec/new")]
        public int AddMec([FromBody]string newMec)
        {
            try
            {
                NewMecDTO newMecDTO = JsonConvert.DeserializeObject<NewMecDTO>(newMec);

                int addedMecId = _panjService.AddMec(newMecDTO);

                return addedMecId;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                Exception up = new HttpResponseException(HttpStatusCode.BadRequest);
                throw up;
            }
        }

        [HttpPost]
        [Route("api/panj/igrac/update")]
        public void UpdateIgrac([FromBody] string uIgr)
        {
            IgracDTO igracDTO = JsonConvert.DeserializeObject<IgracDTO>(uIgr);
            _panjService.UpdateIgrac(igracDTO);
        }

        [HttpPost]
        [Route("api/panj/igra/new")]
        public int AddIgra([FromBody]string newIgra)
        {
            try
            {
                newIgraDTO newIgraDTO = JsonConvert.DeserializeObject<newIgraDTO>(newIgra);

                int igra = _panjService.AddIgra(newIgraDTO);
                return igra;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                Exception up = new HttpResponseException(HttpStatusCode.BadRequest);
                throw up;
            }
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
