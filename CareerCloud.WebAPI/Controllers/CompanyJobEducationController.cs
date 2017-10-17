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
    public class CompanyJobEducationController : ApiController
    {
        private CompanyJobEducationLogic _logic;
        public CompanyJobEducationController()
        {
            var repo = new EFGenericRepository<CompanyJobEducationPoco>(false);
            _logic = new CompanyJobEducationLogic(repo);
        }
        [HttpGet]
        [Route("JobEducation/{CompanyJobEducationId}")]
        [ResponseType(typeof(CompanyJobEducationPoco))]
        public IHttpActionResult GetCompanyJobEducation(Guid CompanyJobEducationId)
        {
            CompanyJobEducationPoco companyJobEducation = _logic.Get(CompanyJobEducationId);
            if (companyJobEducation == null)
            {
                return NotFound();
            }
            return Ok(companyJobEducation);
        }

        [HttpGet]
        [Route("JobEducation")]
        [ResponseType(typeof(List<CompanyJobEducationPoco>))]
        public IHttpActionResult GetAllCompanyJobEducation()
        {
            var companyJobEducationList = _logic.GetAll();
            if (companyJobEducationList == null)
            {
                return NotFound();
            }
            return Ok(companyJobEducationList);
        }


        [HttpPost]
        [Route("JobEducation")]
        public IHttpActionResult PostCompanyJobEducation([FromBody] CompanyJobEducationPoco[] CompanyJobEducations)
        {
            _logic.Add(CompanyJobEducations);
            return Ok();
        }


        [HttpPut]
        [Route("JobEducation")]
        public IHttpActionResult PutCompanyJobEducation([FromBody] CompanyJobEducationPoco[] CompanyJobEducations)
        {
            _logic.Update(CompanyJobEducations);
            return Ok();
        }

        [HttpDelete]
        [Route("JobEducation")]
        public IHttpActionResult DeleteCompanyJobEducation([FromBody] CompanyJobEducationPoco[] CompanyJobEducations)
        {
            _logic.Delete(CompanyJobEducations);
            return Ok();
        }
    }
}
