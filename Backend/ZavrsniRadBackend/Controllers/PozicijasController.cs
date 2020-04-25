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
    [Route("api/pozicija")]
    [ApiController]
    public class PozicijasController : ControllerBase
    {
        private readonly HokejKlubContext _context;

        public PozicijasController(HokejKlubContext context)
        {
            _context = context;
        }

        // GET: api/Pozicijas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pozicija>>> GetPozicija()
        {
            return await _context.Pozicija.ToListAsync();
        }

        // GET: api/Pozicijas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pozicija>> GetPozicija(int id)
        {
            var pozicija = await _context.Pozicija.FindAsync(id);

            if (pozicija == null)
            {
                return NotFound();
            }

            return pozicija;
        }

        // PUT: api/Pozicijas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPozicija(int id, Pozicija pozicija)
        {
            if (id != pozicija.Id)
            {
                return BadRequest();
            }

            _context.Entry(pozicija).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PozicijaExists(id))
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

        // POST: api/Pozicijas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pozicija>> PostPozicija(Pozicija pozicija)
        {
            _context.Pozicija.Add(pozicija);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PozicijaExists(pozicija.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPozicija", new { id = pozicija.Id }, pozicija);
        }

        // DELETE: api/Pozicijas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pozicija>> DeletePozicija(int id)
        {
            var pozicija = await _context.Pozicija.FindAsync(id);
            if (pozicija == null)
            {
                return NotFound();
            }

            _context.Pozicija.Remove(pozicija);
            await _context.SaveChangesAsync();

            return pozicija;
        }

        private bool PozicijaExists(int id)
        {
            return _context.Pozicija.Any(e => e.Id == id);
        }
    }
}
