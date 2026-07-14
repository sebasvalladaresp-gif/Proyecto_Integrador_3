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
    public class EstadoPartidosController : ControllerBase
    {
        private readonly Api_IntegradorContext _context;

        public EstadoPartidosController(Api_IntegradorContext context)
        {
            _context = context;
        }

        // GET: api/EstadoPartidoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoPartido>>> GetEstadoPartidoes()
        {
            return await _context.EstadoPartidoes.ToListAsync();
        }

        // GET: api/EstadoPartidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoPartido>> GetEstadoPartido(int id)
        {
            var estado = await _context.EstadoPartidoes.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        // POST: api/EstadoPartidos
        [HttpPost]
        public async Task<ActionResult<EstadoPartido>> PostEstadoPartido(EstadoPartido estadoPartido)
        {
            _context.EstadoPartidoes.Add(estadoPartido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstadoPartido), new { id = estadoPartido.ID }, estadoPartido);
        }

        // PUT: api/EstadoPartidos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoPartido(int id, EstadoPartido estadoPartido)
        {
            if (id != estadoPartido.ID)
            {
                return BadRequest();
            }

            _context.Entry(estadoPartido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoPartidoExists(id))
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

        // DELETE: api/EstadoPartidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoPartido(int id)
        {
            var estado = await _context.EstadoPartidoes.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.EstadoPartidoes.Remove(estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoPartidoExists(int id)
        {
            return _context.EstadoPartidoes.Any(e => e.ID == id);
        }
    }
}
