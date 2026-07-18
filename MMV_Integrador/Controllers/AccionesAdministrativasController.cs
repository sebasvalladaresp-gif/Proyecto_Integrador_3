using Api_Consumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos_Integrador;

namespace MMV_Integrador.Controllers
{
    public class AccionesAdministrativasController : Controller
    {
        // GET: AccionesAdministrativasController
        public ActionResult Index()
        {

            return View(Crud<AccionAdministrativa>.ReadAll());
        }

        // GET: AccionesAdministrativasController/Details/5
        public ActionResult Details(int id)
        {
            return View(Crud<AccionAdministrativa>.ReadById(id.ToString()));
        }

        // GET: AccionesAdministrativasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccionesAdministrativasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccionAdministrativa accion)
        {
            try
            {
                Crud<AccionAdministrativa>.Create(accion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(accion);
            }
        }

        // GET: AccionesAdministrativasController/Edit/5
        public ActionResult Edit(int id)
        {
            var accion = Crud<AccionAdministrativa>.ReadById(id.ToString());
            if(accion == null) return NotFound();
            return View(accion);
        }

        // POST: AccionesAdministrativasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AccionAdministrativa accion)
        {
            try
            {
                Crud<AccionAdministrativa>.Update(id.ToString(), accion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccionesAdministrativasController/Delete/5
        public ActionResult Delete(int id)
        {
            var accion = Crud<AccionAdministrativa>.ReadById(id.ToString());
            if(accion == null) return NotFound();
            return View(accion);
        }

        // POST: AccionesAdministrativasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AccionAdministrativa accion)
        {
            try
            {
                Crud<AccionAdministrativa>.Delete(id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) {
                ViewData["error"] = ex.Message;
                return View(accion);
            }
        }
    }
}
