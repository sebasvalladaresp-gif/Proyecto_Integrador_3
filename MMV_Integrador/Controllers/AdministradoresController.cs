using Api_Consumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelos_Integrador;
using DTO_Integrador;

namespace MMV_Integrador.Controllers
{
    public class AdministradoresController : Controller
    {
       

        // GET: AdministradoresController
        public ActionResult Index()
        {
            // Uso el DTO: no necesito exponer la contraseña en el listado
            var administradores = Crud<AdministradorDTO>.ReadAll();
            return View(administradores);
        }

        // GET: AdministradoresController/Details/5
        public ActionResult Details(int id)
        {
            var administrador = Crud<AdministradorDTO>.ReadById(id.ToString());
            return View(administrador);
        }

        // GET: AdministradoresController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: AdministradoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Administrador administrador)
        {
            try
            {
                Crud<Administrador>.Create(administrador);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
               
                return View(administrador);
            }
        }

        // GET: AdministradoresController/Edit/5
        public ActionResult Edit(int id)
        {
            // Acá sí necesito la entidad completa (no el DTO), porque el formulario
            // necesita el RolId real para preseleccionar el combo.
            var administrador = Crud<Administrador>.ReadById(id.ToString());
         
            return View(administrador);
        }

        // POST: AdministradoresController/Edit/5
        // POST: AdministradoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Administrador administrador)
        {
            try
            {
                // Obligamos a que el ID del objeto coincida con el ID de la ruta
                administrador.ID = id;

                // Actualizamos usando administrador.ID.ToString() por mayor seguridad
                Crud<Administrador>.Update(administrador.ID.ToString(), administrador);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // ESTO ES CLAVE: Mostrará el error en la vista en lugar de fallar en silencio
                ModelState.AddModelError("", "Ocurrió un error al guardar: " + ex.Message);

                return View(administrador);
            }
        }

        // GET: AdministradoresController/Delete/5
        public ActionResult Delete(int id)
        {
            var administrador = Crud<AdministradorDTO>.ReadById(id.ToString());
            return View(administrador);
        }

        // POST: AdministradoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Crud<Administrador>.Delete(id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}