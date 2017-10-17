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
    public class SystemCountryCodeController : ApiController
    {
        private SystemCountryCodeLogic _logic;
        public SystemCountryCodeController()
        {
            var repo = new EFGenericRepository<SystemCountryCodePoco>(false);
            _logic = new SystemCountryCodeLogic(repo);
        }

        [HttpGet]
        [Route("CountryCode/{SystemCountryCodeId}")]
        [ResponseType(typeof(SystemCountryCodePoco))]
        public IHttpActionResult GetSystemCountryCode(string SystemCountryCodeId)
        {
            SystemCountryCodePoco systemCountryCode = _logic.Get(SystemCountryCodeId);
            if (systemCountryCode == null)
            {
                return NotFound();
            }
            return Ok(systemCountryCode);
        }

        [HttpGet]
        [Route("CountryCode")]
        [ResponseType(typeof(List<SystemCountryCodePoco>))]
        public IHttpActionResult GetAllSystemCountryCode()
        {
            var systemCountryCodeList = _logic.GetAll();
            if (systemCountryCodeList == null)
            {
                return NotFound();
            }
            return Ok(systemCountryCodeList);
        }


        [HttpPost]
        [Route("CountryCode")]
        public IHttpActionResult PostSystemCountryCode([FromBody] SystemCountryCodePoco[] SystemCountryCodes)
        {
            _logic.Add(SystemCountryCodes);
            return Ok();
        }


        [HttpPut]
        [Route("CountryCode")]
        public IHttpActionResult PutSystemCountryCode([FromBody] SystemCountryCodePoco[] SystemCountryCodes)
        {
            _logic.Update(SystemCountryCodes);
            return Ok();
        }


        [HttpDelete]
        [Route("CountryCode")]
        public IHttpActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] SystemCountryCodes)
        {
            _logic.Delete(SystemCountryCodes);
            return Ok();
        }
    }
}
