using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontedPublicoMVC.Controllers
{
    public class PrediccionesController : Controller
    {
        // GET: PrediccionesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PrediccionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrediccionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrediccionesController/Create
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

        // GET: PrediccionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrediccionesController/Edit/5
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

        // GET: PrediccionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrediccionesController/Delete/5
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
