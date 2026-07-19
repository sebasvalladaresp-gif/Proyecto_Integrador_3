using Api_Consumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO_Integrador;

namespace FrontedPublicoMVC.Controllers
{
    public class GruposController : Controller
    {
        public ActionResult Index()
        {
            var grupos = Crud<GrupoDTO>.ReadAll();
            return View(grupos);
        }

        // GET: Grupos/Details/5
        public ActionResult Details(int id)
        {
            var grupo = Crud<GrupoDTO>.ReadById(id.ToString());
            if (grupo == null) return NotFound();
            return View(grupo);
        }
    }
}