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
            _panjService = new PanjService(uow, mecRepository,timRepository,timPripadnostRepository,suciRepository,preprekeRepository,korisnikRepository, igraRepository, igracRepository);
        }


        #region gets

        [Route("api/panj/mec/aktivni")]
        public IEnumerable<MecDTO> GetAktivni()
        {
            return _panjService.GetAktivni();
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

        [HttpPost]
        [Route("api/panj/igra/toggleAktiv")]
        public void SetAktivIgra([FromBody] string iid)
        {
            try
            {
                int igraId = JsonConvert.DeserializeObject<int>(iid);

                _panjService.SetAktivIgra(igraId);

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
