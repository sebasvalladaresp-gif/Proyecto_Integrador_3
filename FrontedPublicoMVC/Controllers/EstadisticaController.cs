using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontedPublicoMVC.Controllers
{
    public class EstadisticaController : Controller
    {
        // GET: EstadisticaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EstadisticaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EstadisticaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadisticaController/Create
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

        // GET: EstadisticaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstadisticaController/Edit/5
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

        // GET: EstadisticaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstadisticaController/Delete/5
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
