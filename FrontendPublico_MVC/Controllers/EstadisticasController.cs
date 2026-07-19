using Microsoft.AspNetCore.Mvc;
using Api_Consumer;
using DTO_Integrador; // Asegúrate de tener esta referencia

namespace FrontendPublico_MVC.Controllers
{
    public class EstadisticasController : Controller
    {
        // GET: EstadisticasController
        public ActionResult Index()
        {
            try
            {
                // Consumimos la lista de partidos configurada en Program.cs
                var partidos = Crud<PartidoDTO>.ReadAll();
                return View(partidos);
            }
            catch (Exception)
            {
                // Si falla la API, enviamos una lista vacía para no romper la vista
                return View(new List<PartidoDTO>());
            }
        }

        // GET: EstadisticasController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                // Consumimos el detalle por ID
                var partido = Crud<PartidoDTO>.ReadById(id.ToString());
                return View(partido);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}