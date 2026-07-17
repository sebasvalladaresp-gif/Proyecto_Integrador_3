using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MMV_Integrador.Controllers
{
    public class ConfederacionesController : Controller
    {
        // GET: ConfederacionesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConfederacionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConfederacionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConfederacionesController/Create
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

        // GET: ConfederacionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConfederacionesController/Edit/5
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

        // GET: ConfederacionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConfederacionesController/Delete/5
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
