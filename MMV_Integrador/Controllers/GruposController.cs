using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MMV_Integrador.Controllers
{
    public class GruposController : Controller
    {
        // GET: GruposController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GruposController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GruposController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GruposController/Create
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

        // GET: GruposController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GruposController/Edit/5
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

        // GET: GruposController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GruposController/Delete/5
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
