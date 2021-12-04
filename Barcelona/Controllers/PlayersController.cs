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
    public class PlayersController : ControllerBase
    {
        private IPlayer _player;

        public PlayersController(IPlayer p)
        {
            _player = p;
        }
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            // You should count the list ...
            var list = await _player.GetPlayers();
            return Ok(list);
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            Player player = await _player.GetPlayer(id);
            return player;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            var updatedPlayer = await _player.UpdatePlayer(id, player);

            return Ok(updatedPlayer);
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            await _player.CreatePlayer(player);

            // Return a 201 Header to browser
            // The body of the request will be us running GetCourse(id);
            return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            await _player.DeletePlayer(id);
            return NoContent();
        }
    }
}
