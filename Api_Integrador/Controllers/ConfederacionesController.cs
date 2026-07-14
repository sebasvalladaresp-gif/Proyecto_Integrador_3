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
    public class ConfederacionesController : ControllerBase
    {
        private readonly Api_IntegradorContext _context;

        public ConfederacionesController(Api_IntegradorContext context)
        {
            _context = context;
        }

        // GET: api/Confederaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Confederacion>>> GetConfederaciones()
        {
            return await _context.Confederaciones.ToListAsync();
        }

        // GET: api/Confederaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Confederacion>> GetConfederacion(int id)
        {
            var conf = await _context.Confederaciones.FindAsync(id);

            if (conf == null)
            {
                return NotFound();
            }

            return conf;
        }

        // POST: api/Confederaciones
        [HttpPost]
        public async Task<ActionResult<Confederacion>> PostConfederacion(Confederacion confederacion)
        {
            _context.Confederaciones.Add(confederacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConfederacion), new { id = confederacion.ID }, confederacion);
        }

        // PUT: api/Confederaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfederacion(int id, Confederacion confederacion)
        {
            if (id != confederacion.ID)
            {
                return BadRequest();
            }

            _context.Entry(confederacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfederacionExists(id))
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

        // DELETE: api/Confederaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfederacion(int id)
        {
            var conf = await _context.Confederaciones.FindAsync(id);
            if (conf == null)
            {
                return NotFound();
            }

            _context.Confederaciones.Remove(conf);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfederacionExists(int id)
        {
            return _context.Confederaciones.Any(e => e.ID == id);
        }
    }
}
