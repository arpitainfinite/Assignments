using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>
    {
        new Country { ID = 1, CountryName = "USA", Capital = "Washington D.C." },
        new Country { ID = 2, CountryName = "UK", Capital = "London" },
        new Country { ID = 3, CountryName = "India", Capital = "New Delhi" },
        new Country { ID = 4, CountryName = "South Korea", Capital = "Seoul" }

    };

        // GET: api/Country
        public IHttpActionResult Get()
        {
            return Ok(countries);
        }

        // GET: api/Country/5
        public IHttpActionResult Get(int id)
        {
            Country country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        // POST: api/Country
        public IHttpActionResult Post(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            country.ID = countries.Count + 1;
            countries.Add(country);

            return CreatedAtRoute("DefaultApi", new { id = country.ID }, country);
        }

        // PUT: api/Country/5
        public IHttpActionResult Put(int id, Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Country existingCountry = countries.FirstOrDefault(c => c.ID == id);
            if (existingCountry == null)
            {
                return NotFound();
            }

            existingCountry.CountryName = country.CountryName;
            existingCountry.Capital = country.Capital;

            return Ok(existingCountry);
        }

        // DELETE: api/Country/5
        public IHttpActionResult Delete(int id)
        {
            Country country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }

            countries.Remove(country);

            return Ok(country);
        }
    }
}
