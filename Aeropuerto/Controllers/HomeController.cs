using System.Web.Mvc;

namespace Aeropuerto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}