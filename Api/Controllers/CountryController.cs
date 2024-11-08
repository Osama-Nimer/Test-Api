using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Model;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet("Country")]
        public Country GetCountry(int ID) { 
            Country country = Country.Find(ID);
            return country;
            
        }
    }
}
