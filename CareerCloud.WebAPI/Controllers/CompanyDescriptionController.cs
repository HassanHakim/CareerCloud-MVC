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
    public class CompanyDescriptionController : ApiController
    {
        private CompanyDescriptionLogic _logic;
        
        public CompanyDescriptionController()
        {
            var repo = new EFGenericRepository<CompanyDescriptionPoco>(false);
            _logic = new CompanyDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("Description/{CompanyDescriptionId}")]
        [ResponseType(typeof(CompanyDescriptionPoco))]
        public IHttpActionResult GetCompanyDescription(Guid CompanyDescriptionId)
        {
            CompanyDescriptionPoco companyDescription = _logic.Get(CompanyDescriptionId);
            if (companyDescription == null)
            {
                return NotFound();
            }
            return Ok(companyDescription);
        }


        [HttpGet]
        [Route("Description")]
        [ResponseType(typeof(List<CompanyDescriptionPoco>))]
        public IHttpActionResult GetAllCompanyDescription()
        {
            var companyDescriptionList = _logic.GetAll();
            if (companyDescriptionList == null)
            {
                return NotFound();
            }
            return Ok(companyDescriptionList);
        }


        [HttpPost]
        [Route("Description")]
        public IHttpActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] companyDescription)
        {
            _logic.Add(companyDescription);
            return Ok();
        }


        [HttpPut]
        [Route("Description")]
        public IHttpActionResult PutCompanyDescription([FromBody] CompanyDescriptionPoco[] companyDescription)
        {
            _logic.Update(companyDescription);
            return Ok();
        }

        [HttpDelete]
        [Route("Description")]
        public IHttpActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] companyDescription)
        {
            _logic.Delete(companyDescription);
            return Ok();
        }
      
    }   
}
