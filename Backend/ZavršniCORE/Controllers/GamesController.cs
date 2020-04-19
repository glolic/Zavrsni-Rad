using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZavršniCORE.Models;

namespace ZavršniCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly HokeJKlubContext _context;

        public GamesController(HokeJKlubContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Games>>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Games>> GetGames(int id)
        {
            var games = await _context.Games.FindAsync(id);

            if (games == null)
            {
                return NotFound();
            }

            return games;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGames(int id, Games games)
        {
            if (id != games.Id)
            {
                return BadRequest();
            }

            _context.Entry(games).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Games
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Games>> PostGames(Games games)
        {
            _context.Games.Add(games);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GamesExists(games.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGames", new { id = games.Id }, games);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Games>> DeleteGames(int id)
        {
            var games = await _context.Games.FindAsync(id);
            if (games == null)
            {
                return NotFound();
            }

            _context.Games.Remove(games);
            await _context.SaveChangesAsync();

            return games;
        }

        private bool GamesExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
