using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MMV_Integrador.Controllers
{
    public class RegistrosAuditoriasController : Controller
    {
        // GET: RegistrosAuditoriasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistrosAuditoriasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrosAuditoriasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrosAuditoriasController/Create
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

        // GET: RegistrosAuditoriasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrosAuditoriasController/Edit/5
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

        // GET: RegistrosAuditoriasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrosAuditoriasController/Delete/5
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
