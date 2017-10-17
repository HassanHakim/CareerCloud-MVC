using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/system/v1")]
    public class SystemLanguageCodeController : ApiController
    {
        private SystemLanguageCodeLogic _logic;
        public SystemLanguageCodeController()
        {
            var repo = new EFGenericRepository<SystemLanguageCodePoco>(false);
            _logic = new SystemLanguageCodeLogic(repo);
        }

        [HttpGet]
        [Route("LanguageCode/{SystemLanguageCodeId}")]
        [ResponseType(typeof(SystemLanguageCodePoco))]
        public IHttpActionResult GetSystemLanguageCode(string SystemLanguageCodeId)
        {
            SystemLanguageCodePoco systemLanguageCode = _logic.Get(SystemLanguageCodeId);
            if (systemLanguageCode == null)
            {
                return NotFound();
            }
            return Ok(systemLanguageCode);
        }

        [HttpGet]
        [Route("LanguageCode")]
        [ResponseType(typeof(List<SystemLanguageCodePoco>))]
        public IHttpActionResult GetAllSystemLanguageCode()
        {
            var systemLanguageCodeList = _logic.GetAll();
            if (systemLanguageCodeList == null)
            {
                return NotFound();
            }
            return Ok(systemLanguageCodeList);
        }


        [HttpPost]
        [Route("LanguageCode")]
        public IHttpActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] SystemLanguageCodes)
        {
            _logic.Add(SystemLanguageCodes);
            return Ok();
        }


        [HttpPut]
        [Route("LanguageCode")]
        public IHttpActionResult PutSystemLanguageCode([FromBody] SystemLanguageCodePoco[] SystemLanguageCodes)
        {
            _logic.Update(SystemLanguageCodes);
            return Ok();
        }

        [HttpDelete]
        [Route("LanguageCode")]
        public IHttpActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] SystemLanguageCodes)
        {
            _logic.Delete(SystemLanguageCodes);
            return Ok();
        }
    }
}
