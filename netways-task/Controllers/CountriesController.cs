using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using netways_task.DAL;
using netways_task.Models;
using netways_task.Security;

namespace netways_task.Controllers
{
    [NetwaysAuth]
    public class CountriesController : ApiController
    {
        private ICountryRepository countriesRepository;

        public CountriesController()
        {
            this.countriesRepository = new CountryRepository(new NetwaysContext());
        }

        public CountriesController(ICountryRepository countriesRepository)
        {
            this.countriesRepository = countriesRepository;
        }

        [AllowAnonymous]
        // GET: api/Countries
        public IEnumerable<Country> GetCountries()
        {
            return countriesRepository.GetCountries();
        }

        // GET: api/Countries/5
        [ResponseType(typeof(Country))]
        public IHttpActionResult GetCountry(int id)
        {
            Country country = countriesRepository.GetCountryByID(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // PUT: api/Countries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCountry(int id, Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.ID)
            {
                return BadRequest();
            }

            countriesRepository.UpdateCountry(country);
            countriesRepository.Save();

         

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Countries
        [ResponseType(typeof(Country))]
        public IHttpActionResult PostCountry(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            countriesRepository.InsertCountry(country);
            countriesRepository.Save();
           
           
            return CreatedAtRoute("DefaultApi", new { id = country.ID }, country);
        }

        // DELETE: api/Countries/5
        [ResponseType(typeof(Country))]
        public IHttpActionResult DeleteCountry(int id)
        {
            Country country = countriesRepository.GetCountryByID(id);
            if (country == null)
            {
                return NotFound();
            }

            countriesRepository.DeleteCountry(id);
            countriesRepository.Save();

            return Ok(country);
        }

        protected override void Dispose(bool disposing)
        {
            countriesRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}