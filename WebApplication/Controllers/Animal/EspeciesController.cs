using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.DAL.Cadastros;
using WebApplication.Models;

namespace WebApplication.Controllers.Animal
{
    public class EspeciesController : Controller
    {
        private EspecieDAL especieDAL = new EspecieDAL();

        private ActionResult ObterVisaoEspeciePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Especie especie = especieDAL.ObterEspeciePorId((long)id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        private ActionResult GravarEspecie(Especie especie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    especieDAL.GravarEspecie(especie);
                    return RedirectToAction("Index");
                }
                return View(especie);
            }
            catch
            {
                return View(especie);
            }
        }
        public ActionResult Index()
        {
            return View(especieDAL.ObterEspeciesClassificadasPorId());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Especie especie)
        {
            return GravarEspecie(especie);
        }

        public ActionResult Edit(long? id)
        {
            return ObterVisaoEspeciePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Especie especie)
        {
            return GravarEspecie(especie);
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoEspeciePorId(id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoEspeciePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Especie especie = especieDAL.EliminarEspeciePorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}