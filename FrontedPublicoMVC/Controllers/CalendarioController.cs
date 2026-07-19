using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Api_Consumer;
using DTO_Integrador;

namespace Publico_Integrador.Controllers
{
    public class CalendarioController : Controller
    {
        // GET: Calendario/Index?fase=Octavos
        public ActionResult Index(string? fase)
        {
            var partidos = Crud<PartidoDTO>.ReadAll();

            // Combo de fases: se arma con los valores que ya trae el propio listado,
            // no hace falta un endpoint aparte de FaseDeJuego para esto.
            ViewBag.Fases = partidos.Select(p => p.Fase).Distinct().OrderBy(f => f).ToList();
            ViewBag.FaseSeleccionada = fase;

            if (!string.IsNullOrEmpty(fase))
                partidos = partidos.Where(p => p.Fase == fase).ToList();

            return View(partidos);
        }

        // GET: Calendario/Details/5
        public ActionResult Details(int id)
        {
            // La API tiene una ruta distinta para el detalle ("api/Partidos/{id}")
            // que para el listado ("api/Partidos/PartidosDTO"), y Crud<T> solo
            // admite un Endpoint fijo por tipo. Filtramos en memoria para no
            // pelear contra esa limitacion (dataset chico: 104 partidos como maximo).
            var partido = Crud<PartidoDTO>.ReadAll().FirstOrDefault(p => p.Id == id);

            if (partido == null)
                return NotFound();

            // El marcador solo existe si el partido esta "En curso" o "Finalizado".
            // La API devuelve 204 No Content en cualquier otro caso, que Crud<T>
            // deserializa como null (no tira excepcion), asi que alcanza con
            // chequear null en la vista.
            PartidoMarcadorDTO? marcador = null;
            try
            {
                marcador = Crud<PartidoMarcadorDTO>.ReadById(id.ToString());
            }
            catch
            {
                marcador = null;
            }

            ViewBag.Marcador = marcador;

            return View(partido);
        }
    }
}