using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.DAL.Cadastros;
using WebApplication.Models;

namespace WebApplication.Controllers.Prestadores
{
    public class VeterinariosController : Controller
    {
        private VeterinarioDAL veterinarioDAL = new VeterinarioDAL();

        private ActionResult ObterVisaoVeterinarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Veterinario veterinario = veterinarioDAL.ObterVeterinarioPorId((long)id);
            if (veterinario == null)
            {
                return HttpNotFound();
            }
            return View(veterinario);
        }

        private ActionResult GravarVeterinario(Veterinario veterinario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    veterinarioDAL.GravarVeterinario(veterinario);
                    return RedirectToAction("Index");
                }
                return View(veterinario);
            }
            catch
            {
                return View(veterinario);
            }
        }
        public ActionResult Index()
        {
            return View(veterinarioDAL.ObterVeterinariosClassificadosPorCrmv());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Veterinario veterinario)
        {
            return GravarVeterinario(veterinario);
        }

        public ActionResult Edit(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Veterinario veterinario)
        {
            return GravarVeterinario(veterinario);
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Veterinario veterinario = veterinarioDAL.EliminarVeterinarioPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}