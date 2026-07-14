using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Integrador.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos_Integrador;

namespace Api_Integrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadiosController : ControllerBase
    {
        private readonly Api_IntegradorContext _context;

        public EstadiosController(Api_IntegradorContext context)
        {
            _context = context;
        }

        // GET: api/Estadios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estadio>>> GetEstadios()
        {
            return await _context.Estadios.ToListAsync();
        }

        // GET: api/Estadios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estadio>> GetEstadio(int id)
        {
            var estadio = await _context.Estadios.FindAsync(id);

            if (estadio == null)
            {
                return NotFound();
            }

            return estadio;
        }

        // POST: api/Estadios
        [HttpPost]
        public async Task<ActionResult<Estadio>> PostEstadio(Estadio estadio)
        {
            _context.Estadios.Add(estadio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstadio), new { id = estadio.ID }, estadio);
        }

        // PUT: api/Estadios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadio(int id, Estadio estadio)
        {
            if (id != estadio.ID)
            {
                return BadRequest();
            }

            _context.Entry(estadio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadioExists(id))
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

        // DELETE: api/Estadios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadio(int id)
        {
            var estadio = await _context.Estadios.FindAsync(id);
            if (estadio == null)
            {
                return NotFound();
            }

            _context.Estadios.Remove(estadio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadioExists(int id)
        {
            return _context.Estadios.Any(e => e.ID == id);
        }
    }
}
