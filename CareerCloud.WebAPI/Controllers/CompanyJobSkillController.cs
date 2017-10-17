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
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyJobSkillController : ApiController
    {
        private CompanyJobSkillLogic _logic;
        public CompanyJobSkillController()
        {
            var repo = new EFGenericRepository<CompanyJobSkillPoco>(false);
            _logic = new CompanyJobSkillLogic(repo);
        }

        [HttpGet]
        [Route("JobSkill/{CompanyJobSkillId}")]
        [ResponseType(typeof(CompanyJobSkillPoco))]
        public IHttpActionResult GetCompanyJobSkill(Guid CompanyJobSkillId)
        {
            CompanyJobSkillPoco companyJobSkill = _logic.Get(CompanyJobSkillId);
            if (companyJobSkill == null)
            {
                return NotFound();
            }
            return Ok(companyJobSkill);
        }

        [HttpGet]
        [Route("JobSkill")]
        [ResponseType(typeof(List<CompanyJobSkillPoco>))]
        public IHttpActionResult GetAllCompanyJobSkill()
        {
            var companyJobSkillList = _logic.GetAll();
            if (companyJobSkillList == null)
            {
                return NotFound();
            }
            return Ok(companyJobSkillList);
        }


        [HttpPost]
        [Route("JobSkill")]
        public IHttpActionResult PostCompanyJobSkill([FromBody] CompanyJobSkillPoco[] CompanyJobSkills)
        {
            _logic.Add(CompanyJobSkills);
            return Ok();
        }

        [HttpPut]
        [Route("JobSkill")]
        public IHttpActionResult PutCompanyJobSkill([FromBody] CompanyJobSkillPoco[] CompanyJobSkills)
        {
            _logic.Update(CompanyJobSkills);
            return Ok();
        }

        [HttpDelete]
        [Route("JobSkill")]
        public IHttpActionResult DeleteCompanyJobSkill([FromBody] CompanyJobSkillPoco[] CompanyJobSkills)
        {
            _logic.Delete(CompanyJobSkills);
            return Ok();
        }
    }
}
