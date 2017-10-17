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
    public class ApplicantProfileController : ApiController
    {
        private ApplicantProfileLogic _logic;
        public ApplicantProfileController()
        {
            var repo = new EFGenericRepository<ApplicantProfilePoco>(false);
            _logic = new ApplicantProfileLogic(repo);
        }

        [HttpGet]
        [Route("Profile/{ApplicantProfileId}")]
        [ResponseType(typeof(ApplicantProfilePoco))]
        public IHttpActionResult GetApplicantProfile(Guid ApplicantProfileId)
        {
            ApplicantProfilePoco applicantProfile = _logic.Get(ApplicantProfileId);
            if (applicantProfile == null)
            {
                return NotFound();
            }
            return Ok(applicantProfile);
        }

        [HttpGet]
        [Route("Profile")]
        [ResponseType(typeof(List<ApplicantProfilePoco>))]
        public IHttpActionResult GetAllApplicantProfile()
        {
            var applicantProfileList = _logic.GetAll();
            if (applicantProfileList == null)
            {
                return NotFound();
            }
            return Ok(applicantProfileList);
        }


        [HttpPost]
        [Route("Profile")]
        public IHttpActionResult PostApplicantProfile([FromBody] ApplicantProfilePoco[] applicantProfiles)
        {
            _logic.Add(applicantProfiles);
            return Ok();
        }


        [HttpPut]
        [Route("Profile")]
        public IHttpActionResult PutApplicantProfile([FromBody] ApplicantProfilePoco[] applicantProfiles)
        {
            _logic.Update(applicantProfiles);
            return Ok();
        }

        [HttpDelete]
        [Route("Profile")]
        public IHttpActionResult DeleteApplicantProfile([FromBody] ApplicantProfilePoco[] applicantProfiles)
        {
            _logic.Delete(applicantProfiles);
            return Ok();
        }
    }
}
