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
    public class GruposController : ControllerBase
    {
        private readonly Api_IntegradorContext _context;

        public GruposController(Api_IntegradorContext context)
        {
            _context = context;
        }

        // GET: api/Grupos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoDTO>>> GetGrupos()
        {
            var grupos = await _context.Grupos
                .Include(g => g.Selecciones)
                .AsNoTracking()
                .ToListAsync();

            var partidosFinalizados = await ObtenerPartidosFinalizadosAsync();

            var resultado = grupos.Select(g => ArmarGrupoDTO(g, partidosFinalizados)).ToList();
            return Ok(resultado);
        }

        // GET: api/Grupos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoDTO>> GetGrupo(int id)
        {
            var grupo = await _context.Grupos
                .Include(g => g.Selecciones)
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.ID == id);

            if (grupo == null)
                return NotFound();

            var partidosFinalizados = await ObtenerPartidosFinalizadosAsync();
            return Ok(ArmarGrupoDTO(grupo, partidosFinalizados));
        }

        // Trae solo los partidos ya finalizados (con marcador cargado),
        // que son los unicos que cuentan para la tabla de posiciones.
        private async Task<List<Partido>> ObtenerPartidosFinalizadosAsync()
        {
            return await _context.Partidos
                .Include(p => p.Estado)
                .AsNoTracking()
                .Where(p => p.Estado != null
                    && p.Estado.Nombre == "Finalizado"
                    && p.GolesLocal != null
                    && p.GolesVisitante != null)
                .ToListAsync();
        }

        // Calcula PJ, G, E, P, GF, GC, DG y Puntos de cada seleccion del grupo,
        // recorriendo sus partidos como local y como visitante (HU5).
        // Orden: puntos desc, diferencia de goles desc, goles a favor desc.
        private GrupoDTO ArmarGrupoDTO(Grupo grupo, List<Partido> partidosFinalizados)
        {
            var seleccionesDto = grupo.Selecciones!.Select(s =>
            {
                var partidosDeLaSeleccion = partidosFinalizados
                    .Where(p => p.SeleccionLocalID == s.ID || p.SeleccionVisitanteID == s.ID)
                    .ToList();

                int ganados = 0, empatados = 0, perdidos = 0, golesFavor = 0, golesContra = 0;

                foreach (var p in partidosDeLaSeleccion)
                {
                    bool esLocal = p.SeleccionLocalID == s.ID;
                    int propios = esLocal ? p.GolesLocal!.Value : p.GolesVisitante!.Value;
                    int rivales = esLocal ? p.GolesVisitante!.Value : p.GolesLocal!.Value;

                    golesFavor += propios;
                    golesContra += rivales;

                    if (propios > rivales) ganados++;
                    else if (propios == rivales) empatados++;
                    else perdidos++;
                }

                return new SeleccionEstadisticaDTO
                {
                    nombre = s.Nombre,
                    idGrupo = grupo.ID,
                    partidosJugados = partidosDeLaSeleccion.Count,
                    partidosGanados = ganados,
                    partidosEmpatados = empatados,
                    partidosPerdidos = perdidos,
                    golesAFavor = golesFavor,
                    golesEnContra = golesContra,
                    diferenciaGoles = golesFavor - golesContra,
                    puntos = (ganados * 3) + empatados
                };
            })
            .OrderByDescending(s => s.puntos)
            .ThenByDescending(s => s.diferenciaGoles)
            .ThenByDescending(s => s.golesAFavor)
            .ToList();

            return new GrupoDTO
            {
                Id = grupo.ID,
                Name = grupo.Nombre,
                Selecciones = seleccionesDto
            };
        }

        // POST: api/Grupos
        [HttpPost]
        public async Task<ActionResult<Grupo>> PostGrupo(Grupo grupo)
        {
            _context.Grupos.Add(grupo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGrupo), new { id = grupo.ID }, grupo);
        }

        // PUT: api/Grupos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupo(int id, Grupo grupo)
        {
            if (id != grupo.ID)
            {
                return BadRequest();
            }

            _context.Entry(grupo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoExists(id))
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

        // DELETE: api/Grupos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupo(int id)
        {
            var grupo = await _context.Grupos.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }

            _context.Grupos.Remove(grupo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrupoExists(int id)
        {
            return _context.Grupos.Any(e => e.ID == id);
        }
    }
}