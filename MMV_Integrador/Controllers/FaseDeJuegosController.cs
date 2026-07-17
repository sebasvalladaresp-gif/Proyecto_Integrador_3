using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MMV_Integrador.Controllers
{
    public class FaseDeJuegosController : Controller
    {
        // GET: FaseDeJuegosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FaseDeJuegosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FaseDeJuegosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FaseDeJuegosController/Create
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

        // GET: FaseDeJuegosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FaseDeJuegosController/Edit/5
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

        // GET: FaseDeJuegosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FaseDeJuegosController/Delete/5
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
