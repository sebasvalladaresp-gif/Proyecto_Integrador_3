using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontedPublicoMVC.Controllers
{
    public class RankingController : Controller
    {
        // GET: RankingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RankingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
