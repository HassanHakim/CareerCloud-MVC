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
    public class ApplicantJobApplicationController : ApiController
    {
        private ApplicantJobApplicationLogic _logic;
        public ApplicantJobApplicationController()
        {
            //var repo = new ApplicantJobApplicationRepository();
            var repo = new EFGenericRepository<ApplicantJobApplicationPoco>(false);
            _logic = new ApplicantJobApplicationLogic(repo);
        }

        [HttpGet]
        [Route("JobApplication/{ApplicantJobApplicationId}")]
        [ResponseType(typeof(ApplicantJobApplicationPoco))]
        public IHttpActionResult GetApplicantJobApplication(Guid ApplicantJobApplicationId)
        {
            ApplicantJobApplicationPoco applicantJobApplication = _logic.Get(ApplicantJobApplicationId);
            if (applicantJobApplication == null)
            {
                return NotFound();
            }
            return Ok(applicantJobApplication);
        }

        [HttpGet]
        [Route("JobApplication")]
        [ResponseType(typeof(List<ApplicantJobApplicationPoco>))]
        public IHttpActionResult GetAllApplicantJobApplication()
        {
            var applicantJobApplicationList = _logic.GetAll();
            if (applicantJobApplicationList == null)
            {
                return NotFound();
            }
            return Ok(applicantJobApplicationList);
        }


        [HttpPost]
        [Route("JobApplication")]
        public IHttpActionResult PostApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] applicantJobApplications)
        {
            _logic.Add(applicantJobApplications);
            return Ok();
        }


        [HttpPut]
        [Route("JobApplication")]
        public IHttpActionResult PutApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] applicantJobApplications)
        {
            _logic.Update(applicantJobApplications);
            return Ok();
        }

        [HttpDelete]
        [Route("JobApplication")]
        public IHttpActionResult DeleteApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] applicantJobApplications)
        {
            _logic.Delete(applicantJobApplications);
            return Ok();
        }
    }
}
