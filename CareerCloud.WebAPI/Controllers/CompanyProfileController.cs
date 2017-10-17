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
    public class CompanyProfileController : ApiController
    {
        private CompanyProfileLogic _logic;
        public CompanyProfileController()
        {
            var repo = new EFGenericRepository<CompanyProfilePoco>(false);
            _logic = new CompanyProfileLogic(repo);
        }

        [HttpGet]
        [Route("Profile/{CompanyProfileId}")]
        [ResponseType(typeof(CompanyProfilePoco))]
        public IHttpActionResult GetCompanyProfile(Guid CompanyProfileId)
        {
            CompanyProfilePoco companyProfile = _logic.Get(CompanyProfileId);
            if (companyProfile == null)
            {
                return NotFound();
            }
            return Ok(companyProfile);
        }

        [HttpGet]
        [Route("Profile")]
        [ResponseType(typeof(List<CompanyProfilePoco>))]
        public IHttpActionResult GetAllCompanyProfile()
        {
            var companyProfileList = _logic.GetAll();
            if (companyProfileList == null)
            {
                return NotFound();
            }
            return Ok(companyProfileList);
        }


        [HttpPost]
        [Route("Profile")]
        public IHttpActionResult PostCompanyProfile([FromBody] CompanyProfilePoco[] CompanyProfiles)
        {
            _logic.Add(CompanyProfiles);
            return Ok();
        }


        [HttpPut]
        [Route("Profile")]
        public IHttpActionResult PutCompanyProfile([FromBody] CompanyProfilePoco[] CompanyProfiles)
        {
            _logic.Update(CompanyProfiles);
            return Ok();
        }

        [HttpDelete]
        [Route("Profile")]
        public IHttpActionResult DeleteCompanyProfile([FromBody] CompanyProfilePoco[] CompanyProfiles)
        {
            _logic.Delete(CompanyProfiles);
            return Ok();
        }
    }
}
