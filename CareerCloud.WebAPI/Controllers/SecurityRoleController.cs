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
    public class SecurityRoleController : ApiController
    {    
        private SecurityRoleLogic _logic;
        public SecurityRoleController()
        {
            var repo = new EFGenericRepository<SecurityRolePoco>(false);
            _logic = new SecurityRoleLogic(repo);
        }

        [HttpGet]
        [Route("Role/{SecurityRoleId}")]
        [ResponseType(typeof(SecurityRolePoco))]
        public IHttpActionResult GetSecurityRole(Guid SecurityRoleId)
        {
            SecurityRolePoco securityRole = _logic.Get(SecurityRoleId);
            if (securityRole == null)
            {
                return NotFound();
            }
            return Ok(securityRole);
        }

        [HttpGet]
        [Route("Role")]
        [ResponseType(typeof(List<SecurityRolePoco>))]
        public IHttpActionResult GetAllSecurityRole()
        {
            var securityRoleList = _logic.GetAll();
            if (securityRoleList == null)
            {
                return NotFound();
            }
            return Ok(securityRoleList);
        }


        [HttpPost]
        [Route("Role")]
        public IHttpActionResult PostSecurityRole([FromBody] SecurityRolePoco[] SecurityRoles)
        {
            _logic.Add(SecurityRoles);
            return Ok();
        }


        [HttpPut]
        [Route("Role")]
        public IHttpActionResult PutSecurityRole([FromBody] SecurityRolePoco[] SecurityRoles)
        {
            _logic.Update(SecurityRoles);
            return Ok();
        }

        [HttpDelete]
        [Route("Role")]
        public IHttpActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] SecurityRoles)
        {
            _logic.Delete(SecurityRoles);
            return Ok();
        }
    }

}
