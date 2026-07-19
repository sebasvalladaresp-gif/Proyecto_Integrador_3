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
    public class PartidosController : ControllerBase
    {
        private readonly Api_IntegradorContext _context;

        public PartidosController(Api_IntegradorContext context)
        {
            _context = context;
        }

        // GET: api/Partidos/PartidosDTO
        // HU4: calendario completo, ordenado cronologicamente (fecha y luego hora)
        [HttpGet("PartidosDTO")]
        public async Task<ActionResult<IEnumerable<PartidoDTO>>> GetPartidos()
        {
            var partidos = await _context.Partidos
             .OrderBy(p => p.Fecha)
             .ThenBy(p => p.Hora)
             .Select(p => new PartidoDTO
             {
                 Id = p.ID,
                 SeleccionLocal = p.SeleccionLocal == null ? "Por definir" : p.SeleccionLocal.Nombre,

                 SeleccionVisitante = p.SeleccionVisitante == null ? "Por definir" : p.SeleccionVisitante.Nombre,
                 Fecha = p.Fecha,
                 Hora = p.Hora,
                 Estadio = p.Estadio == null ? "No definido" : p.Estadio.Nombre,
                 Fase = p.Fase == null ? "No definida" : p.Fase.Nombre,
                 Estado = p.Estado == null ? "No definido" : p.Estado.Nombre
             })
            .ToListAsync();

            return Ok(partidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PartidoDTO>> GetPartido(int id)
        {
            var partido = await _context.Partidos
                .Select(p => new PartidoDTO
                {
                    Id = p.ID,
                    SeleccionLocal = p.SeleccionLocal == null ? "Por definir" : p.SeleccionLocal.Nombre,
                    SeleccionVisitante = p.SeleccionVisitante == null ? "Por definir" : p.SeleccionVisitante.Nombre,
                    Fecha = p.Fecha,
                    Hora = p.Hora,
                    Estadio = p.Estadio == null ? "No definido" : p.Estadio.Nombre,
                    Fase = p.Fase == null ? "No definida" : p.Fase.Nombre,
                    Estado = p.Estado == null ? "No definido" : p.Estado.Nombre
                })
                .FirstOrDefaultAsync();

            if (partido == null)
                return NotFound();

            return Ok(partido);
        }

        // GET: api/Partidos/Marcador/5
        // HU6 (extend "Mostrar marcador"): solo devuelve datos si el partido
        // esta "En curso" o "Finalizado". Si todavia no arranco, 204 No Content
        // (el frontend interpreta "sin marcador" y no muestra nada).
        // Ruta con el id al final ("Marcador/{id}"), no al principio, para que
        // coincida con como Crud<T>.ReadById arma la URL (Endpoint + "/" + id).
        [HttpGet("Marcador/{id}")]
        public async Task<ActionResult<PartidoMarcadorDTO>> GetMarcador(int id)
        {
            var partido = await _context.Partidos
                .Include(p => p.Estado)
                .FirstOrDefaultAsync(p => p.ID == id);

            if (partido == null)
                return NotFound();

            var nombreEstado = partido.Estado?.Nombre ?? "";
            if (nombreEstado != "En curso" && nombreEstado != "Finalizado")
                return NoContent();

            return Ok(new PartidoMarcadorDTO
            {
                GolSeleccion1 = partido.GolesLocal ?? 0,
                GolSeleccion2 = partido.GolesVisitante ?? 0
            });
        }

        // POST: api/Partidos
        [HttpPost]
        public async Task<ActionResult<Partido>> PostPartido(Partido partido)
        {
            _context.Partidos.Add(partido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPartido), new { id = partido.ID }, partido);
        }

        // PUT: api/Partidos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartido(int id, Partido partido)
        {
            if (id != partido.ID)
            {
                return BadRequest();
            }

            _context.Entry(partido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartidoExists(id))
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

        // DELETE: api/Partidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartido(int id)
        {
            var partido = await _context.Partidos.FindAsync(id);
            if (partido == null)
            {
                return NotFound();
            }

            _context.Partidos.Remove(partido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartidoExists(int id)
        {
            return _context.Partidos.Any(e => e.ID == id);
        }
    }
}