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
    public class ApplicantWorkHistoryController : ApiController
    {
        private ApplicantWorkHistoryLogic _logic;
        public ApplicantWorkHistoryController()
        {
            var repo = new EFGenericRepository<ApplicantWorkHistoryPoco>(false);
            _logic = new ApplicantWorkHistoryLogic(repo);
        }

        [HttpGet]
        [Route("WorkHistory/{ApplicantWorkHistoryId}")]
        [ResponseType(typeof(ApplicantWorkHistoryPoco))]
        public IHttpActionResult GetApplicantWorkHistory(Guid ApplicantWorkHistoryId)
        {
            ApplicantWorkHistoryPoco applicantWorkHistory = _logic.Get(ApplicantWorkHistoryId);
            if (applicantWorkHistory == null)
            {
                return NotFound();
            }
            return Ok(applicantWorkHistory);
        }

        [HttpGet]
        [Route("WorkHistory")]
        [ResponseType(typeof(List<ApplicantWorkHistoryPoco>))]
        public IHttpActionResult GetAllApplicantWorkHistory()
        {
            var applicantWorkHistoryList = _logic.GetAll();
            if (applicantWorkHistoryList == null)
            {
                return NotFound();
            }
            return Ok(applicantWorkHistoryList);
        }


        [HttpPost]
        [Route("WorkHistory")]
        public IHttpActionResult PostApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] applicantWorkHistory)
        {
            _logic.Add(applicantWorkHistory);
            return Ok();
        }


        [HttpPut]
        [Route("WorkHistory")]
        public IHttpActionResult PutApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] applicantWorkHistory)
        {
            _logic.Update(applicantWorkHistory);
            return Ok();
        }

        [HttpDelete]
        [Route("WorkHistory")]
        public IHttpActionResult DeleteApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] applicantWorkHistory)
        {
            _logic.Delete(applicantWorkHistory);
            return Ok();
        }
    }
}
