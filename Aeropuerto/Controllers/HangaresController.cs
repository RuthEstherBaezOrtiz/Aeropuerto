using Aeropuerto.models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Aeropuerto.Controllers
{
    public class HangaresController : Controller
    {


        AEROPUERTOContext context = new AEROPUERTOContext();


        // Aciones de crear
        public ActionResult Agregar(Hangares hangares, bool message = false)
        {
            ViewBag.message = message;

            return View(hangares);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregando(Hangares hangares)
        {
            context.Hangares.Add(hangares);

            try
            {
                if (context.SaveChanges() == -1)
                    return HttpNotFound();
            }
            catch
            {
                return RedirectToAction("Agregar", new { message = true });
            }

            return RedirectToAction("Mostrar");
        }



        // Aciones de editar
        public ActionResult Modificar(int? id, bool message = false)
        {
            ViewBag.message = message;

            return View(context.Hangares.First(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(Hangares hangares)
        {
            context.Hangares.Update(hangares);

            try
            {
                if (context.SaveChanges() == -1)
                    return HttpNotFound();
            }
            catch
            {
                return RedirectToAction("Modificar", new { id = hangares.Id, message = true });
            }

            return RedirectToAction("Mostrar");
        }



        // Aciones de eliminar
        public ActionResult Eliminar(int? id, bool message = false)
        {
            ViewBag.message = message;

            return View(context.Hangares.First(x => x.Id == id));
        }


        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            Hangares hangares = context.Hangares.Find(id);
            context.Hangares.Remove(hangares);

            try
            {
                if (context.SaveChanges() == -1)
                    return HttpNotFound();
            }
            catch
            {
                return RedirectToAction("Eliminar", new { id = id, message = true });
            }

            return RedirectToAction("Mostrar");
        }



        // Acion de mostrar
        public ActionResult Mostrar()
        {
            List<Hangares> hangares = new List<Hangares>();

            hangares = context.Hangares.ToList();

            return View(hangares);
        }


    }
}