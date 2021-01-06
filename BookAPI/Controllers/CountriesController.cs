using BookApiProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApiProject.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class CountriesController : Controller
    {
        private ICountryRepository _countryRepository;
        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        //api/countries
        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = _countryRepository.GetCountries().ToList();

            return Ok(countries);
        }
    }
}
