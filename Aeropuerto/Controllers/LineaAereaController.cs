using Aeropuerto.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Aeropuerto.Controllers
{
    public class LineaAereaController : Controller
    {
        AEROPUERTOContext context = new AEROPUERTOContext();


        // Aciones de crear
        public ActionResult Agregar(LineaAerea lineaAerea, bool message = false)
        {
            ViewBag.message = message;

            return View(lineaAerea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregando(LineaAerea lineaAerea,string ListEstatus)
        {
            lineaAerea.Estatus = bool.Parse(ListEstatus);

            context.LineaAerea.Add(lineaAerea);

            try
            {
                if (context.SaveChanges() == -1)
                    return HttpNotFound();
            }
            catch(Exception ex)
            {
                ex.Message.ToString();

                return RedirectToAction("Agregar", new { message = true });
            }

            return RedirectToAction("Mostrar");
        }



        // Aciones de editar
        public ActionResult Modificar(int? id, bool message = false)
        {
            ViewBag.message = message;

            return View(context.LineaAerea.First(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(LineaAerea lineaAerea, bool ListEstatus)
        {
            lineaAerea.Estatus = ListEstatus;

            context.LineaAerea.Update(lineaAerea);

            try
            {
                if (context.SaveChanges() == -1)
                    return HttpNotFound();
            }
            catch
            {
                return RedirectToAction("Modificar", new { id = lineaAerea.Id, message = true });
            }

            return RedirectToAction("Mostrar");
        }



        // Aciones de eliminar
        public ActionResult Eliminar(int? id, bool message = false)
        {
            ViewBag.message = message;

            return View(context.LineaAerea.First(x => x.Id == id));
        }


        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            LineaAerea lineaAerea = context.LineaAerea.Find(id);
            context.LineaAerea.Remove(lineaAerea);

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
            List<LineaAerea> lineaAerea = new List<LineaAerea>();

            lineaAerea = context.LineaAerea.ToList();

            return View(lineaAerea);
        }


    }
}