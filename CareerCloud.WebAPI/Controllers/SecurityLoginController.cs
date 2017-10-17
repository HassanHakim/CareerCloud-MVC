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
    [RoutePrefix("api/careercloud/security/v1")]
    public class SecurityLoginController : ApiController
    {
        private SecurityLoginLogic _logic;
        public SecurityLoginController()
        {
            //var repo = new SecurityLoginRepository();
            var repo = new EFGenericRepository<SecurityLoginPoco>(false);
            _logic = new SecurityLoginLogic(repo);
        }

        [HttpGet]
        [Route("login/{loginId}")]
        [ResponseType(typeof(SecurityLoginPoco))]
        public IHttpActionResult GetSecurityLogin(Guid loginId)
        {
            SecurityLoginPoco secLogin = _logic.Get(loginId);
            if (secLogin == null)
            {
                return NotFound();
            }
            return Ok(secLogin);
        }

        [HttpGet]
        [Route("login")]
        [ResponseType(typeof(List<SecurityLoginPoco>))]
        public IHttpActionResult GetAllSecurityLogin()
        {
            List<SecurityLoginPoco> pocos = _logic.GetAll();            
            return Ok(pocos);
        }

        [HttpPost]
        [Route("login")]       
        public IHttpActionResult PostSecurityLogin([FromBody] SecurityLoginPoco[] securityLogin)
        {
            _logic.Add(securityLogin);
            return Ok();
        }

        [HttpPut]
        [Route("login")]
        public IHttpActionResult PutSecurityLogin([FromBody] SecurityLoginPoco[] securityLogin)
        {
            _logic.Update(securityLogin);
            return Ok();
        }

        [HttpDelete]
        [Route("login")]
        public IHttpActionResult DeleteSecurityLogin([FromBody] SecurityLoginPoco[] securityLogin)
        {
            _logic.Delete(securityLogin);
            return Ok();
        }

    }
}
