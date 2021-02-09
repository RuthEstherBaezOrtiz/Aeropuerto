using System.Web.Mvc;

namespace Aeropuerto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregando2()
        {
            try
            {
                    return HttpNotFound();
            }
            catch
            {
                return RedirectToAction("Agregar", new { message = true });
            }

            return RedirectToAction("Mostrar");
        }
    }
}