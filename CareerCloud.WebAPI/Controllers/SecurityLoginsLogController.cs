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
    public class SecurityLoginsLogController : ApiController
    {
        private SecurityLoginsLogLogic _logic;
        public SecurityLoginsLogController()
        {
            var repo = new EFGenericRepository<SecurityLoginsLogPoco>(false);
            _logic = new SecurityLoginsLogLogic(repo);
        }
        [HttpGet]
        [Route("LoginsLog/{SecurityLoginsLogId}")]
        [ResponseType(typeof(SecurityLoginsLogPoco))]                                
        public IHttpActionResult GetSecurityLoginLog(Guid SecurityLoginsLogId)
        {
            SecurityLoginsLogPoco securityLoginsLog = _logic.Get(SecurityLoginsLogId);
            if (securityLoginsLog == null)
            {
                return NotFound();
            }
            return Ok(securityLoginsLog);
        }

        [HttpGet]
        [Route("LoginsLog")]
        [ResponseType(typeof(List<SecurityLoginsLogPoco>))]
        public IHttpActionResult GetAllSecurityLoginLog()
        {
            var securityLoginsLogList = _logic.GetAll();
            if (securityLoginsLogList == null)
            {
                return NotFound();
            }
            return Ok(securityLoginsLogList);
        }


        [HttpPost]
        [Route("LoginsLog")]
        public IHttpActionResult PostSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] SecurityLoginsLogs)
        {
            _logic.Add(SecurityLoginsLogs);
            return Ok();
        }


        [HttpPut]
        [Route("LoginsLog")]
        public IHttpActionResult PutSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] SecurityLoginsLogs)
        {
            _logic.Update(SecurityLoginsLogs);
            return Ok();
        }

        [HttpDelete]
        [Route("LoginsLog")]
        public IHttpActionResult DeleteSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] SecurityLoginsLogs)
        {
            _logic.Delete(SecurityLoginsLogs);
            return Ok();
        }
    }
}
