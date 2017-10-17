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
    public class CompanyJobsDescriptionController : ApiController
    {
        private CompanyJobDescriptionLogic _logic;
        public CompanyJobsDescriptionController()
        {
            var repo = new EFGenericRepository<CompanyJobDescriptionPoco>(false);
            _logic = new CompanyJobDescriptionLogic(repo);
        }
        [HttpGet]
        [Route("JobDescription/{CompanyJobDescriptionId}")]
        [ResponseType(typeof(CompanyJobDescriptionPoco))]
        public IHttpActionResult GetCompanyJobsDescription(Guid CompanyJobDescriptionId)
        {
            CompanyJobDescriptionPoco companyJobDescription = _logic.Get(CompanyJobDescriptionId);
            if (companyJobDescription == null)
            {
                return NotFound();
            }
            return Ok(companyJobDescription);
        }

        [HttpGet]
        [Route("JobDescription")]
        [ResponseType(typeof(List<CompanyJobDescriptionPoco>))]
        public IHttpActionResult GetAllCompanyJobsDescription()
        {
            var companyJobDescriptionList = _logic.GetAll();
            if (companyJobDescriptionList == null)
            {
                return NotFound();
            }
            return Ok(companyJobDescriptionList);
        }


        [HttpPost]
        [Route("JobDescription")]
        public IHttpActionResult PostCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] CompanyJobDescriptions)
        {
            _logic.Add(CompanyJobDescriptions);
            return Ok();
        }


        [HttpPut]
        [Route("JobDescription")]
        public IHttpActionResult PutCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] CompanyJobDescriptions)
        {
            _logic.Update(CompanyJobDescriptions);
            return Ok();
        }

        [HttpDelete]
        [Route("JobDescription")]
        public IHttpActionResult DeleteCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] CompanyJobDescriptions)
        {
            _logic.Delete(CompanyJobDescriptions);
            return Ok();
        }
    }
}
