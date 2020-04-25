using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZavrsniRadBackend.Models;

namespace ZavrsniRadBackend.Controllers
{
    [Route("api/spol")]
    [ApiController]
    public class SpolsController : ControllerBase
    {
        private readonly HokejKlubContext _context;

        public SpolsController(HokejKlubContext context)
        {
            _context = context;
        }

        // GET: api/Spols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spol>>> GetSpol()
        {
            return await _context.Spol.ToListAsync();
        }

        // GET: api/Spols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spol>> GetSpol(int id)
        {
            var spol = await _context.Spol.FindAsync(id);

            if (spol == null)
            {
                return NotFound();
            }

            return spol;
        }

        // PUT: api/Spols/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpol(int id, Spol spol)
        {
            if (id != spol.Id)
            {
                return BadRequest();
            }

            _context.Entry(spol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpolExists(id))
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

        // POST: api/Spols
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Spol>> PostSpol(Spol spol)
        {
            _context.Spol.Add(spol);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpolExists(spol.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSpol", new { id = spol.Id }, spol);
        }

        // DELETE: api/Spols/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Spol>> DeleteSpol(int id)
        {
            var spol = await _context.Spol.FindAsync(id);
            if (spol == null)
            {
                return NotFound();
            }

            _context.Spol.Remove(spol);
            await _context.SaveChangesAsync();

            return spol;
        }

        private bool SpolExists(int id)
        {
            return _context.Spol.Any(e => e.Id == id);
        }
    }
}
