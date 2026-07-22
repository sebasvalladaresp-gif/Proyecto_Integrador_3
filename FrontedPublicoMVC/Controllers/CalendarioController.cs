using Api_Consumer;
using DTO_Integrador;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Publico_Integrador.Controllers
{
    public class CalendarioController : Controller
    {
        // GET: RankingController
        public ActionResult Index()
        {
            
            return View(Crud<PartidoDTO>.ReadAll());
        }

        // GET: RankingController/Details/5
        public ActionResult Details(int id)
        {
          
            var dato = Crud<PartidoDTO>.ReadById(id.ToString());
            if (dato != null)
                return View(dato);

            return NotFound();

            
        }

        // GET: RankingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RankingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RankingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RankingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RankingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RankingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}