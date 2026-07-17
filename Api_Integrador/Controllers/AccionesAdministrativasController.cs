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
    public class AccionesAdministrativasController : ControllerBase
    {
        private readonly Api_IntegradorContext _context;

        public AccionesAdministrativasController(Api_IntegradorContext context)
        {
            _context = context;
        }

        // GET: api/AccionesAdministrativas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccionAdministrativa>>> GetAccionesAdministrativas()
        {
            return await _context.AccionesAdministrativas.ToListAsync();
        }

        // GET: api/AccionesAdministrativas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccionAdministrativa>> GetAccionAdministrativa(int id)
        {
            var accion = await _context.AccionesAdministrativas.FindAsync(id);

            if (accion == null)
            {
                return NotFound();
            }

            return accion;
        }

        // PUT: api/AccionesAdministrativas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccionAdministrativa(int id, AccionAdministrativa accionAdministrativa)
        {
            if (id != accionAdministrativa.Id)
            {
                return BadRequest();
            }

            _context.Entry(accionAdministrativa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccionAdministrativaExists(id))
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

        // POST: api/AccionesAdministrativas
        [HttpPost]
        public async Task<ActionResult<AccionAdministrativa>> PostAccionAdministrativa(AccionAdministrativa accionAdministrativa)
        {
            _context.AccionesAdministrativas.Add(accionAdministrativa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAccionAdministrativa), new { id = accionAdministrativa.Id }, accionAdministrativa);
        }

        // DELETE: api/AccionesAdministrativas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccionAdministrativa(int id)
        {
            var accion = await _context.AccionesAdministrativas.FindAsync(id);
            if (accion == null)
            {
                return NotFound();
            }

            _context.AccionesAdministrativas.Remove(accion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccionAdministrativaExists(int id)
        {
            return _context.AccionesAdministrativas.Any(e => e.Id == id);
        }
    }
}
