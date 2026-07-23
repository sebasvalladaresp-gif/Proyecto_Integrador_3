using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Integrador.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos_Integrador;
using DTO_Integrador;
namespace Api_Integrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeleccionesController : ControllerBase
    {
        private readonly Api_IntegradorContext _context;

        public SeleccionesController(Api_IntegradorContext context)
        {
            _context = context;
        }

        // GET: api/Selecciones
        [HttpGet("SeleccionDto")]
        public async Task<ActionResult<IEnumerable<SeleccionDto>>> GetSelecciones()
        {
            var seleccion = await _context.selecciones
            .Select(s => new SeleccionDto
            {
                Id = s.ID,
                Nombre = s.Nombre,
                CodigoFifa = s.CodigoFifa,
                Confederacion = s.Confederacion == null ? "No definida": s.Confederacion.ToString(),
                Grupo = s.Grupo == null? "Por definir" : s.Grupo.Nombre
            })
            .ToListAsync();

            return Ok(seleccion);

        }

        // GET: api/Selecciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeleccionDto>> GetSeleccion(int id)
        {
            var seleccion = await _context.selecciones
                .Where(s => s.ID == id)
                .Select(s => new SeleccionDto
                {
                    Id = s.ID,
                    Nombre = s.Nombre,
                    CodigoFifa = s.CodigoFifa,
                    Confederacion = s.Confederacion == null ? "No definida" : s.Confederacion.ToString(),
                    Grupo = s.Grupo == null? "Por definir": s.Grupo.Nombre
                })
                .FirstOrDefaultAsync();

            if (seleccion == null)
                return NotFound();

            return Ok(seleccion);
        }

        // POST: api/Selecciones
        [HttpPost]
        public async Task<ActionResult<Seleccion>> PostSeleccion(Seleccion seleccion)
        {
            _context.selecciones.Add(seleccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeleccion), new { id = seleccion.ID }, seleccion);
        }

        // PUT: api/Selecciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeleccion(int id, Seleccion seleccion)
        {
            if (id != seleccion.ID)
            {
                return BadRequest();
            }

            _context.Entry(seleccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeleccionExists(id))
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

        // DELETE: api/Selecciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeleccion(int id)
        {
            var seleccion = await _context.selecciones.FindAsync(id);
            if (seleccion == null)
            {
                return NotFound();
            }

            _context.selecciones.Remove(seleccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeleccionExists(int id)
        {
            return _context.selecciones.Any(e => e.ID == id);
        }
    }
}
