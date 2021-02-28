using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace World_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldController : ControllerBase
    {

        private readonly IDAL _dal;

        public WorldController(IDAL dal)
        {
            _dal = dal;
        }

        [HttpGet("city")]
        public ActionResult<IList<City>> GetCities( )
        {
            return Ok(_dal.GetCities());
        }

        [HttpGet("country")]
        public ActionResult<IList<Country>> GetCountries()
        {
            return Ok(_dal.GetCountries());
        }

        [HttpGet("language")]
        public ActionResult<IList<City>> GetLanguages()
        {
            return Ok(_dal.GetLanguages());
        }

    }
}
