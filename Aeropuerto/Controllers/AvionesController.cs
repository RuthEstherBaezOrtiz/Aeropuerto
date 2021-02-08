
using Aeropuerto.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Aeropuerto.Controllers
{
    public class AvionesController : Controller
    {


        AEROPUERTOContext context = new AEROPUERTOContext();



        // Aciones de crear
        public ActionResult Agregar(Aviones aviones, bool message = false)
        {
            ViewBag.message = message;

            ViewBag.lineasAereas = context.LineaAerea.ToList();

            return View(aviones);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregando(Aviones aviones, string ListTamaño, int ListLineasAereas)
        {
            aviones.Tamano = ListTamaño;
            aviones.IdLinea = ListLineasAereas;

            context.Aviones.Add(aviones);

            try
            {
                if (context.SaveChanges() == -1)
                    return HttpNotFound();
            }
            catch
            {
                return RedirectToAction("Agregar", new {  message = true });
            }

            return RedirectToAction("Mostrar");
        }



        // Aciones de editar
        public ActionResult Modificar(int? id, bool message = false)
        {
            ViewBag.message = message;

            ViewBag.lineasAereas = context.LineaAerea.ToList();

            return View(context.Aviones.First(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(Aviones aviones, string ListTamaño = null, int? ListLineasAereas = null)
        {
            if(ListTamaño == null || ListLineasAereas == null)
                return RedirectToAction("Modificar", new { id = aviones.Id, message = true });

            aviones.Tamano = ListTamaño;
            aviones.IdLinea = ListLineasAereas.Value;

            context.Aviones.Update(aviones);

            try
            {
                if (context.SaveChanges() == -1)
                    return HttpNotFound();
            }
            catch
            {
                return RedirectToAction("Modificar", new { id = aviones.Id, message = true });
            }

            return RedirectToAction("Mostrar");
        }



        // Aciones de eliminar
        public ActionResult Eliminar(int? id, bool message = false)
        {
            ViewBag.message = message;

            return View(context.Aviones.Include(x => x.IdLineaNavigation).First(x => x.Id == id));
        }


        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            Aviones aviones = context.Aviones.Find(id);
            context.Aviones.Remove(aviones);

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
            List<Aviones> aviones = new List<Aviones>();

            aviones = context.Aviones.Include(x => x.IdLineaNavigation).ToList();

            return View(aviones);
        }


    }

}