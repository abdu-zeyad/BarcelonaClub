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
    public class SportsController : ControllerBase
    {
        private ISport _sport;

        public SportsController(ISport s)
        {
            _sport= s;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sport>>> GetSports()
        {
            // You should count the list ...
            var list = await _sport.GetSports();
            return Ok(list);
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sport>> GetSport(int id)
        {
            Sport sport = await _sport.GetSport(id);
            return sport;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSport(int id, Sport sport)
        {
            if (id != sport.Id)
            {
                return BadRequest();
            }

            var updatedvenue = await _sport.UpdateSport(id, sport);

            return Ok(updatedvenue);
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sport>> PostSport(Sport sport)
        {
            await _sport.CreateSport(sport);

            // Return a 201 Header to browser
            // The body of the request will be us running GetCourse(id);
            return CreatedAtAction("GetSport", new { id = sport.Id }, sport);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSport(int id)
        {
            await _sport.DeleteSport(id);
            return NoContent();
        }

    }
}
