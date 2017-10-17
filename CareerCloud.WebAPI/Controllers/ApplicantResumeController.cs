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
    public class ApplicantResumeController : ApiController
    {
        private ApplicantResumeLogic _logic;
        public ApplicantResumeController()
        {
            var repo = new EFGenericRepository<ApplicantResumePoco>(false);
            _logic = new ApplicantResumeLogic(repo);
        }

        [HttpGet]
        [Route("Resume/{ApplicantResumeId}")]
        [ResponseType(typeof(ApplicantResumePoco))]
        public IHttpActionResult GetApplicantResume(Guid ApplicantResumeId)
        {
            ApplicantResumePoco applicantResume = _logic.Get(ApplicantResumeId);
            if (applicantResume == null)
            {
                return NotFound();
            }
            return Ok(applicantResume);
        }

        [HttpGet]
        [Route("Resume")]
        [ResponseType(typeof(List<ApplicantResumePoco>))]
        public IHttpActionResult GetAllApplicantResume()
        {
            var applicantResumeList = _logic.GetAll();
            if (applicantResumeList == null)
            {
                return NotFound();
            }
            return Ok(applicantResumeList);
        }


        [HttpPost]
        [Route("Resume")]
        public IHttpActionResult PostApplicantResume([FromBody] ApplicantResumePoco[] ApplicantResumes)
        {
            _logic.Add(ApplicantResumes);
            return Ok();
        }


        [HttpPut]
        [Route("Resume")]
        public IHttpActionResult PutApplicantResume([FromBody] ApplicantResumePoco[] ApplicantResumes)
        {
            _logic.Update(ApplicantResumes);
            return Ok();
        }

        [HttpDelete]
        [Route("Resume")]
        public IHttpActionResult DeleteApplicantResume([FromBody] ApplicantResumePoco[] ApplicantResumes)
        {
            _logic.Delete(ApplicantResumes);
            return Ok();
        }
    }
}
