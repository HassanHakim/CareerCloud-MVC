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
    [RoutePrefix("api/careercloud/applicant/v1")]
    public class ApplicantSkillController : ApiController
    {
        private ApplicantSkillLogic _logic;
        public ApplicantSkillController()
        {
            var repo = new EFGenericRepository<ApplicantSkillPoco>(false);
            _logic = new ApplicantSkillLogic(repo);
        }

        [HttpGet]
        [Route("Skill/{ApplicantSkillId}")]
        [ResponseType(typeof(ApplicantSkillPoco))]
        public IHttpActionResult GetApplicantSkill(Guid ApplicantSkillId)
        {
            ApplicantSkillPoco applicantSkill = _logic.Get(ApplicantSkillId);
            if (applicantSkill == null)
            {
                return NotFound();
            }
            return Ok(applicantSkill);
        }

        [HttpGet]
        [Route("Skill")]
        [ResponseType(typeof(List<ApplicantSkillPoco>))]
        public IHttpActionResult GetAllApplicantSkill()
        {
            var applicantSkillList = _logic.GetAll();
            if (applicantSkillList == null)
            {
                return NotFound();
            }
            return Ok(applicantSkillList);
        }


        [HttpPost]
        [Route("Skill")]
        public IHttpActionResult PostApplicantSkill([FromBody] ApplicantSkillPoco[] ApplicantSkills)
        {
            _logic.Add(ApplicantSkills);
            return Ok();
        }


        [HttpPut]
        [Route("Skill")]
        public IHttpActionResult PutApplicantSkill([FromBody] ApplicantSkillPoco[] ApplicantSkills)
        {
            _logic.Update(ApplicantSkills);
            return Ok();
        }

        [HttpDelete]
        [Route("Skill")]
        public IHttpActionResult DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] ApplicantSkills)
        {
            _logic.Delete(ApplicantSkills);
            return Ok();
        }
    }    
}
