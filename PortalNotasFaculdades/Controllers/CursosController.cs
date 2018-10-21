using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalNotasFaculdades.Models;

namespace PortalNotasFaculdades.Controllers
{
    public class CursosController : Controller
    {
        private PortalContext db = new PortalContext();

        // GET: Cursos
        public ActionResult Index()
        {
            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            return View(db.Cursos.Where(m => m.EmailFaculdade == Nomeinst).ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(cursos);
                try
                {
                    db.SaveChanges();
                    TempData["Message"] = "Curso Cadastrado com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["MessageErr"] = "Houve um Erro ao Cadastrar o Curso!";
                    return RedirectToAction("Index");
                }
            }

            return View(cursos);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        // POST: Cursos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursos).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    TempData["Message"] = "Curso Editado com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["MessageErr"] = "Houve um Erro ao Editar o Curso: " + cursos.NomeCurso;
                    return RedirectToAction("Index");
                }
            }
            return View(cursos);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cursos cursos = db.Cursos.Find(id);
            db.Cursos.Remove(cursos);
            try
            {
                db.SaveChanges();
                TempData["Message"] = "Curso Deletado com Sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["MessageErr"] = "Houve um Erro ao Deletar o Curso: " + cursos.NomeCurso;
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
