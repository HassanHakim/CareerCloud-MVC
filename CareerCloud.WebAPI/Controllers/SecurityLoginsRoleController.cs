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
    public class SecurityLoginsRoleController : ApiController
    {
        private SecurityLoginsRoleLogic _logic;
        public SecurityLoginsRoleController()
        {
            var repo = new EFGenericRepository<SecurityLoginsRolePoco>(false);
            _logic = new SecurityLoginsRoleLogic(repo);
        }
        [HttpGet]
        [Route("LoginsRole/{SecurityLoginsRoleId}")]
        [ResponseType(typeof(SecurityLoginsRolePoco))]
        public IHttpActionResult GetSecurityLoginsRole(Guid SecurityLoginsRoleId)
        {
            SecurityLoginsRolePoco securityLoginsRole = _logic.Get(SecurityLoginsRoleId);
            if (securityLoginsRole == null)
            {
                return NotFound();
            }
            return Ok(securityLoginsRole);
        }

        [HttpGet]
        [Route("LoginsRole")]
        [ResponseType(typeof(List<SecurityLoginsRolePoco>))]
        public IHttpActionResult GetAllSecurityLoginsRole()
        {
            var securityLoginsRoleList = _logic.GetAll();
            if (securityLoginsRoleList == null)
            {
                return NotFound();
            }
            return Ok(securityLoginsRoleList);
        }


        [HttpPost]
        [Route("LoginsRole")]                                
        public IHttpActionResult PostSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] SecurityLoginsRoles)
        {
            _logic.Add(SecurityLoginsRoles);
            return Ok();
        }


        [HttpPut]
        [Route("LoginsRole")]
        public IHttpActionResult PutSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] SecurityLoginsRoles)
        {
            _logic.Update(SecurityLoginsRoles);
            return Ok();
        }

        [HttpDelete]
        [Route("LoginsRole")]
        public IHttpActionResult DeleteSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] SecurityLoginsRoles)
        {
            _logic.Delete(SecurityLoginsRoles);
            return Ok();
        }
    }
}
