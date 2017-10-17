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
    public class CompanyJobController : ApiController
    {
        private CompanyJobLogic _logic;
        public CompanyJobController()
        {
            var repo = new EFGenericRepository<CompanyJobPoco>(false);
            _logic = new CompanyJobLogic(repo);
        }
        [HttpGet]
        [Route("Job/{CompanyJobId}")]
        [ResponseType(typeof(CompanyJobPoco))]
        public IHttpActionResult GetCompanyJob(Guid CompanyJobId)
        {
            CompanyJobPoco companyJob = _logic.Get(CompanyJobId);
            if (companyJob == null)
            {
                return NotFound();
            }
            return Ok(companyJob);
        }

        [HttpGet]
        [Route("Job")]
        [ResponseType(typeof(List<CompanyJobPoco>))]
        public IHttpActionResult GetAllCompanyJob()
        {
            var companyJobList = _logic.GetAll();
            if (companyJobList == null)
            {
                return NotFound();
            }
            return Ok(companyJobList);
        }


        [HttpPost]
        [Route("Job")]
        public IHttpActionResult PostCompanyJob([FromBody] CompanyJobPoco[] CompanyJobs)
        {
            _logic.Add(CompanyJobs);
            return Ok();
        }


        [HttpPut]
        [Route("Job")]
        public IHttpActionResult PutCompanyJob([FromBody] CompanyJobPoco[] CompanyJobs)
        {
            _logic.Update(CompanyJobs);
            return Ok();
        }

        [HttpDelete]
        [Route("Job")]
        public IHttpActionResult DeleteCompanyJob([FromBody] CompanyJobPoco[] CompanyJobs)
        {
            _logic.Delete(CompanyJobs);
            return Ok();
        }
    }
}
