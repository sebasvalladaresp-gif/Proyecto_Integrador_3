using Api_Consumer;
using DTO_Integrador;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos_Integrador;

namespace FrontedPublicoMVC.Controllers
{
    public class EliminatoriasController : Controller
    {
        // GET: EliminatoriasController
        public ActionResult Index()
        {
            var partidos = Crud<PartidoDTO>.ReadAll() ?? new List<PartidoDTO>();

            var partidosEliminatorias = partidos
                .Where(p => p.Fase != null && p.Fase != "Fase de Grupos")
                .ToList();

            var fasesEliminatorias = partidosEliminatorias
                .GroupBy(p => p.Fase)
                .ToList();

            return View(fasesEliminatorias);
        }

        // GET: EliminatoriasController/Details/5
        public ActionResult Details(int id)
        {
            var partido = Crud<PartidoDTO>.ReadById(id.ToString());
            if (partido != null)
                return View(partido);

            return NotFound();
        }

        // GET: EliminatoriasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EliminatoriasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FaseDeJuego fase)
        {
            try
            {
                Crud<FaseDeJuego>.Create(fase);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EliminatoriasController/Edit/5
        public ActionResult Edit(int id)
        {
            var dato=Crud<FaseDeJuego>.ReadById(id.ToString());
            if(dato == null) return NotFound();
            return View(dato);
        }

        // POST: EliminatoriasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FaseDeJuego fase)
        {
            try
            {
                Crud<FaseDeJuego>.Update(id.ToString(), fase);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EliminatoriasController/Delete/5
        public ActionResult Delete(int id)
        {
            var dato = Crud<FaseDeJuego>.ReadById(id.ToString());
            if(dato == null) return NotFound();
            return View(dato);
        }

        // POST: EliminatoriasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FaseDeJuego fase)
        {
            try
            {
                Crud<FaseDeJuego>.Delete(id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View(fase);
            }
        }
    }
}
