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
    public class RegistroAuditoriasController : ControllerBase
    {
        private readonly Api_IntegradorContext _context;

        public RegistroAuditoriasController(Api_IntegradorContext context)
        {
            _context = context;
        }

        // GET: api/RegistroAuditorias
        [HttpGet("RegistroAuditoriaDTO")]
        public async Task<ActionResult<IEnumerable<RegistroAuditoriaDTO>>> GetRegistroAuditorias()
        {
            var dtos = await _context.RegistroAuditorias
           .Select(r => new RegistroAuditoriaDTO
            {
                UsuarioAdmin = r.Administrador.Nombre ?? "nombre no identificado",
                FechaHora = r.FechaHora,
                Descripcion = r.Descripcion,
                AccionAdministrativa = r.AccionAdministrativa.Nombre ?? "sin acción definida"
            })
        .ToListAsync();

            return Ok(dtos);
        }

        // GET: api/RegistroAuditorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroAuditoria>> GetRegistroAuditoria(int id)
        {
            var registro = await _context.RegistroAuditorias.FindAsync(id);

            if (registro == null)
            {
                return NotFound();
            }

            return registro;
        }

        // POST: api/RegistroAuditorias
        [HttpPost]
        public async Task<ActionResult<RegistroAuditoria>> PostRegistroAuditoria(RegistroAuditoria registroAuditoria)
        {
            _context.RegistroAuditorias.Add(registroAuditoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRegistroAuditoria), new { id = registroAuditoria.ID }, registroAuditoria);
        }

        // PUT: api/RegistroAuditorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroAuditoria(int id, RegistroAuditoria registroAuditoria)
        {
            if (id != registroAuditoria.ID)
            {
                return BadRequest();
            }

            _context.Entry(registroAuditoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroAuditoriaExists(id))
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

        // DELETE: api/RegistroAuditorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroAuditoria(int id)
        {
            var registro = await _context.RegistroAuditorias.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }

            _context.RegistroAuditorias.Remove(registro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistroAuditoriaExists(int id)
        {
            return _context.RegistroAuditorias.Any(e => e.ID == id);
        }
    }
}
