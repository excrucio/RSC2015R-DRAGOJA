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
            _panjService = new PanjService(uow, mecRepository);
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
                MecDTO mecDTO = JsonConvert.DeserializeObject<MecDTO>(newMec);
                int addedMecId = _panjService.AddMec(mecDTO);

                return addedMecId;

            }
            catch (Exception e)
            {
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
