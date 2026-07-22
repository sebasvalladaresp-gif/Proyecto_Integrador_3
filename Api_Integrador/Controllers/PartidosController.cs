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
                .Include(p => p.SeleccionLocal)
                .Include(p => p.SeleccionVisitante)
                .Include(p => p.Estadio)
                .OrderBy(p => p.Fecha)
                .ThenBy(p => p.Hora)
                .ToListAsync();

            var partidosDTO = partidos.Select(p => new PartidoDTO
            {
                Id = p.ID,
                SeleccionLocal = p.SeleccionLocal == null ? "Por definir" : p.SeleccionLocal.Nombre,
                SeleccionVisitante = p.SeleccionVisitante == null ? "Por definir" : p.SeleccionVisitante.Nombre,
                Fecha = p.Fecha,
                Hora = p.Hora,
                Estadio = p.Estadio == null ? "No definido" : p.Estadio.Nombre,
                Fase = FaseNombre(p.FaseDeJuego),
                Estado = EstadoNombre(p.Estado),
                GolSeleccion1 = p.GolesLocal,
                GolSeleccion2 = p.GolesVisitante
            });
           

            return Ok(partidosDTO);
        }
        private string FaseNombre(FaseDeJuego fase) 
        {
            if(fase == FaseDeJuego.FaseDeGrupos)
                return "Fase de Grupos";
            else if (fase == FaseDeJuego.Dieciseisavos)
                return "Dieciseisavos";
            else if (fase == FaseDeJuego.Octavos)
                return "Octavos";
            else if (fase == FaseDeJuego.Cuartos)
                return "Cuartos";
            else if (fase == FaseDeJuego.Semifinal)
                return "Semifinal";
            else if (fase == FaseDeJuego.TercerPuesto)
                return "Tercer Puesto";
            else if (fase == FaseDeJuego.Final)
                return "Final";
            else
                return "No definida";
        }

        private string EstadoNombre(EstadoPartido estado) 
        {
            if (estado == EstadoPartido.programado)
                return "Programado";
            else if (estado == EstadoPartido.Enjuego)
                return "En curso";
            else if (estado == EstadoPartido.Finalizado)
                return "Finalizado";
            else
                return "No definido";
        }

        [HttpGet("PartidosDTO/{id}")]
        public async Task<ActionResult<PartidoDTO>> GetPartido(int id)
        {
            var p = await _context.Partidos
                .Include(p => p.SeleccionLocal)
                .Include(p => p.SeleccionVisitante)
                .Include(p => p.Estadio)
                .FirstOrDefaultAsync(x => x.ID == id);

            if (p == null)
                return NotFound();

            var partidoDto = new PartidoDTO
            {
                Id = p.ID,
                SeleccionLocal = p.SeleccionLocal?.Nombre ?? "Por definir",
                SeleccionVisitante = p.SeleccionVisitante?.Nombre ?? "Por definir",
                Fecha = p.Fecha,
                Hora = p.Hora,
                Estadio = p.Estadio?.Nombre ?? "No definido",
                Fase = FaseNombre(p.FaseDeJuego),
                Estado = EstadoNombre(p.Estado),
                GolSeleccion1 = p.GolesLocal,
                GolSeleccion2 = p.GolesVisitante
            };

            return Ok(partidoDto);
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