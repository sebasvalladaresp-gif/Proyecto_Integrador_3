using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MMV_Integrador.Controllers
{
    public class EstadosPartidoController : Controller
    {
        // GET: EstadosPartidoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EstadosPartidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EstadosPartidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadosPartidoController/Create
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

        // GET: EstadosPartidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstadosPartidoController/Edit/5
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

        // GET: EstadosPartidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstadosPartidoController/Delete/5
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
