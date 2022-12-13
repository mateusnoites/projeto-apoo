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
    public class SecretariosController : Controller
    {
        private SecretarioDAL secretarioDAL = new SecretarioDAL();

        private ActionResult ObterVisaoSecretarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Secretario secretario = secretarioDAL.ObterSecretarioPorId((long)id);
            if (secretario == null)
            {
                return HttpNotFound();
            }
            return View(secretario);
        }

        private ActionResult GravarSecretario(Secretario secretario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    secretarioDAL.GravarSecretario(secretario);
                    return RedirectToAction("Index");
                }
                return View(secretario);
            }
            catch
            {
                return View(secretario);
            }
        }
        public ActionResult Index()
        {
            return View(secretarioDAL.ObterSecretariosClassificadosPorDataAdmissao());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Secretario secretario)
        {
            return GravarSecretario(secretario);
        }

        public ActionResult Edit(long? id)
        {
            return ObterVisaoSecretarioPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Secretario secretario)
        {
            return GravarSecretario(secretario);
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoSecretarioPorId(id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoSecretarioPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Secretario secretario = secretarioDAL.EliminarSecretarioPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}