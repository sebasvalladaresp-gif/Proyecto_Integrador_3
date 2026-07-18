using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Integrador.Data;
using Modelos_Integrador;
using DTO_Integrador;
namespace Api_Integrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly Api_IntegradorContext _context;

        public AdministradoresController(Api_IntegradorContext context)
        {
            _context = context;
        }

        // GET: api/Administradores
        [HttpGet("AdministradorDTO")]
        public async Task<ActionResult<IEnumerable<AdministradorDTO>>> GetAdministradores()
        {
            return await _context.Administradores.Include(r => r.Rol)
                .Select(a=> new AdministradorDTO {
                    id = a.ID,
                    Nombre = a.Nombre,
                    Correo = a.Correo,
                    RolNombre = (a.Rol == null ? "no definido" : a.Rol.Nombre)
                }).ToListAsync();
        }

        // GET: api/Administradores/5
        // GET: api/Administradores/5  → entidad completa (la usa Crud<Administrador> en Edit)
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);

            if (administrador == null)
                return NotFound();

            return Ok(administrador);
        }

        // GET: api/Administradores/AdministradorDTO/5  → DTO (lo usan Index, Details, Delete)
        [HttpGet("AdministradorDTO/{id}")]
        public async Task<ActionResult<AdministradorDTO>> GetAdministradorDTO(int id)
        {
            var dto = await _context.Administradores
                .Include(a => a.Rol)
                .Where(a => a.ID == id)
                .Select(a => new AdministradorDTO
                {
                    id = a.ID,
                    Nombre = a.Nombre,
                    Correo = a.Correo,
                    RolNombre = a.Rol == null ? "no definido" : a.Rol.Nombre
                })
                .FirstOrDefaultAsync();

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        // POST: api/Administradores
        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdministrador(Administrador administrador)
        {
            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdministrador), new { id = administrador.ID }, administrador);
        }

        // PUT: api/Administradores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(int id, Administrador administrador)
        {
            if (id != administrador.ID)
            {
                return BadRequest();
            }

            _context.Entry(administrador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
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

        // DELETE: api/Administradores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrador(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }

            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administradores.Any(e => e.ID == id);
        }
    }
}
