using Barcelona.Models;
using Barcelona.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcelona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private IVenue _venue;

        public VenuesController(IVenue v)
        {
            _venue = v;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venue>>> GetVenues()
        {
            // You should count the list ...
            var list = await _venue.GetVenues();
            return Ok(list);
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venue>> GetVenue(int id)
        {
            Venue venue = await _venue.GetVenue(id);
            return venue;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenue(int id, Venue venue)
        {
            if (id != venue.Id)
            {
                return BadRequest();
            }

            var updatedvenue = await _venue.UpdateVenue(id, venue);

            return Ok(updatedvenue);
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Venue>> PostCourse(Venue venue)
        {
            await _venue.CreateVenue(venue);

            // Return a 201 Header to browser
            // The body of the request will be us running GetCourse(id);
            return CreatedAtAction("GetCourse", new { id = venue.Id }, venue);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourses(int id)
        {
            await _venue.DeleteVenue(id);
            return NoContent();
        }

        // Add a student to a course
        // POST: api/Courses/5/7
       
    }
}
