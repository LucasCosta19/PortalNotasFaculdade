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
    public class DisciplinasCursosController : Controller
    {
        private PortalContext db = new PortalContext();

        // GET: DisciplinasCursos
        public ActionResult Index()
        {
            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            var disciplinasCursos = db.DisciplinasCursos.OrderBy(d => d.CursoId).Include(d => d.Cursos);
            return View(disciplinasCursos.Where(m => m.EmailFaculdade == Nomeinst && m.NomeDisciplina != "1. Nenhuma").ToList().OrderBy(m => m.Cursos.NomeCurso));
        }

        // GET: DisciplinasCursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisciplinasCursos disciplinasCursos = db.DisciplinasCursos.Find(id);
            if (disciplinasCursos == null)
            {
                return HttpNotFound();
            }
            return View(disciplinasCursos);
        }

        // GET: DisciplinasCursos/Create
        public ActionResult Create()
        {
            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            ViewBag.CursoId = new SelectList(db.Cursos.Where(m => m.EmailFaculdade == Nomeinst).OrderBy(m => m.NomeCurso), "CursoId", "NomeCurso");

            return View();
        }

        // POST: DisciplinasCursos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DisciplinasCursos disciplinasCursos)
        {
            if (ModelState.IsValid)
            {
                db.DisciplinasCursos.Add(disciplinasCursos);
                try
                {
                    db.SaveChanges();
                    TempData["Message"] = "Disciplina Cadastrada com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["MessageErr"] = "Houve um Erro ao Inserir uma Disciplina!";
                    return RedirectToAction("Index");
                }
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "NomeCurso", disciplinasCursos.CursoId);
            return View(disciplinasCursos);
        }

        // GET: DisciplinasCursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisciplinasCursos disciplinasCursos = db.DisciplinasCursos.Find(id);
            if (disciplinasCursos == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "NomeCurso", disciplinasCursos.CursoId);
            return View(disciplinasCursos);
        }

        // POST: DisciplinasCursos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DisciplinasCursos disciplinasCursos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disciplinasCursos).State = EntityState.Modified;
                try
                {
                    TempData["Message"] = "Disciplina Editada com Sucesso!";
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["MessageErr"] = "Houve um Erro ao Tentar Editar essa Disciplina: " + disciplinasCursos.NomeDisciplina;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "NomeCurso", disciplinasCursos.CursoId);
            return View(disciplinasCursos);
        }

        // GET: DisciplinasCursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisciplinasCursos disciplinasCursos = db.DisciplinasCursos.Find(id);
            if (disciplinasCursos == null)
            {
                return HttpNotFound();
            }
            return View(disciplinasCursos);
        }

        // POST: DisciplinasCursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DisciplinasCursos disciplinasCursos = db.DisciplinasCursos.Find(id);
            db.DisciplinasCursos.Remove(disciplinasCursos);
            try
            {
                db.SaveChanges();
                TempData["Message"] = "Disciplina Deletada com Sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["MessageErr"] = "Houve um Erro ao Excluir essa Disciplina: " + disciplinasCursos.NomeDisciplina;
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
