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
    public class CompanyLocationController : ApiController
    {
        private CompanyLocationLogic _logic;
        public CompanyLocationController()
        {
            var repo = new EFGenericRepository<CompanyLocationPoco>(false);
            _logic = new CompanyLocationLogic(repo);
        }

        [HttpGet]
        [Route("Location/{CompanyLocationId}")]
        [ResponseType(typeof(CompanyLocationPoco))]
        public IHttpActionResult GetCompanyLocation(Guid CompanyLocationId)
        {
            CompanyLocationPoco companyLocation = _logic.Get(CompanyLocationId);
            if (companyLocation == null)
            {
                return NotFound();
            }
            return Ok(companyLocation);
        }

        [HttpGet]
        [Route("Location")]
        [ResponseType(typeof(List<CompanyLocationPoco>))]
        public IHttpActionResult GetAllCompanyLocation()
        {
            var companyLocationList = _logic.GetAll();
            if (companyLocationList == null)
            {
                return NotFound();
            }
            return Ok(companyLocationList);
        }


        [HttpPost]
        [Route("Location")]
        public IHttpActionResult PostCompanyLocation([FromBody] CompanyLocationPoco[] CompanyLocations)
        {
            _logic.Add(CompanyLocations);
            return Ok();
        }


        [HttpPut]
        [Route("Location")]
        public IHttpActionResult PutCompanyLocation([FromBody] CompanyLocationPoco[] CompanyLocations)
        {
            _logic.Update(CompanyLocations);
            return Ok();
        }

        [HttpDelete]
        [Route("Location")]
        public IHttpActionResult DeleteCompanyLocation([FromBody] CompanyLocationPoco[] CompanyLocations)
        {
            _logic.Delete(CompanyLocations);
            return Ok();
        }
    }
}
