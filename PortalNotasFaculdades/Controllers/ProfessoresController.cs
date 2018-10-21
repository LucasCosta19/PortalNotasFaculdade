using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalNotas.Classes;
using PortalNotasFaculdades.Models;

namespace PortalNotasFaculdades.Controllers
{
    public class ProfessoresController : Controller
    {
        private PortalContext db = new PortalContext();

        // GET: Professores
        public ActionResult Index()
        {
            var tipo = Convert.ToString(Session["Tipo"]);
            var user = Convert.ToString(Session["EmailUsuario"]);
            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            Professores professoresPortal = db.Professores.FirstOrDefault(a => a.NomeCompleto == User.Identity.Name);

            if (tipo == "Master")
            {
                return View(db.Professores.Where(m => m.EmailFaculdade == Nomeinst).ToList().OrderBy(m => m.CursoIdUm));
            }

            if (tipo == "Professor")
            {
                return View(db.Professores.Where(a => a.EmailUsuario == user).ToList());
            }
            else
            {
                return View();
            }
        }

        // GET: Professores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professores professores = db.Professores.Find(id);
            if (professores == null)
            {
                return HttpNotFound();
            }
            return View(professores);
        }

        // GET: Professores/Create
        public ActionResult Create()
        {
            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            List<Cursos> GetCursos()
            {
                var dep = db.Cursos.Where(m => m.EmailFaculdade == Nomeinst).ToList();
                dep.Add(new Cursos
                {
                    CursoId = 0,
                    NomeCurso = "[Selecione um Curso]"
                });
                return dep = dep.OrderBy(d => d.NomeCurso).ToList();
            }

            ViewData["Countries"] = new SelectList(GetCursos(), "CursoId", "NomeCurso");
            ViewData["CountriesTwo"] = new SelectList(GetCursos(), "CursoId", "NomeCurso");

            List<DisciplinasCursos> GetDisciplinas()
            {
                var dep = db.DisciplinasCursos.Where(m => m.EmailFaculdade == Nomeinst).ToList();
                dep.Add(new DisciplinasCursos
                {
                    DisciplinaId = 0,
                    NomeDisciplina = "[Selecione uma Disciplina]"
                });
                return dep = dep.OrderBy(d => d.NomeDisciplina).ToList();
            }

            ViewBag.DisciplinaCinco = new SelectList(GetDisciplinas(), "DisciplinaId", "NomeDisciplina");
            ViewBag.DisciplinaDois = new SelectList(GetDisciplinas(), "DisciplinaId", "NomeDisciplina");
            ViewBag.DisciplinaQuatro = new SelectList(GetDisciplinas(), "DisciplinaId", "NomeDisciplina");
            ViewBag.DisciplinaSeis = new SelectList(GetDisciplinas(), "DisciplinaId", "NomeDisciplina");
            ViewBag.DisciplinaTres = new SelectList(GetDisciplinas(), "DisciplinaId", "NomeDisciplina");
            ViewBag.DisciplinaUm = new SelectList(GetDisciplinas(), "DisciplinaId", "NomeDisciplina");

            return View();
        }

        // POST: Professores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Professores professores)
        {
            if (ModelState.IsValid)
            {
                db.Professores.Add(professores);
                try
                {
                    db.SaveChanges();
                    TempData["Message"] = "Professor Cadastrado com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["MessageErr"] = "Houve um Erro ao Tentar Cadastrar o Professor: " + professores.NomeCompleto;
                    return RedirectToAction("Index");
                }
            }

            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            ViewData["Countries"] = new SelectList(CombosHelper.GetCursos().Where(m => m.EmailFaculdade == Nomeinst), "CursoId", "NomeCurso", professores.CursoIdUm);
            ViewData["CountriesTwo"] = new SelectList(CombosHelper.GetCursos().Where(m => m.EmailFaculdade == Nomeinst), "CursoId", "NomeCurso", professores.CursoIdDois);

            ViewBag.DisciplinaCinco = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaCinco);
            ViewBag.DisciplinaDois = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaDois);
            ViewBag.DisciplinaQuatro = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaQuatro);
            ViewBag.DisciplinaSeis = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaSeis);
            ViewBag.DisciplinaTres = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaTres);
            ViewBag.DisciplinaUm = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaUm);

            return View(professores);
        }

        // GET: Professores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professores professores = db.Professores.Find(id);
            if (professores == null)
            {
                return HttpNotFound();
            }

            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            List<Cursos> GetCursos()
            {
                var dep = db.Cursos.Where(m => m.EmailFaculdade == Nomeinst).ToList();
                dep.Add(new Cursos
                {
                    CursoId = 0,
                    NomeCurso = "[Selecione um Curso]"
                });
                return dep = dep.OrderBy(d => d.NomeCurso).ToList();
            }

            ViewData["Countries"] = new SelectList(GetCursos(), "CursoId", "NomeCurso", professores.CursoIdUm);
            ViewData["CountriesTwo"] = new SelectList(GetCursos(), "CursoId", "NomeCurso", professores.CursoIdDois);

            ViewBag.DisciplinaCinco = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaCinco);
            ViewBag.DisciplinaDois = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaDois);
            ViewBag.DisciplinaQuatro = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaQuatro);
            ViewBag.DisciplinaSeis = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaSeis);
            ViewBag.DisciplinaTres = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaTres);
            ViewBag.DisciplinaUm = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaUm);
            return View(professores);
        }

        // POST: Professores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Professores professores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professores).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    TempData["Message"] = "Professor Editado com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["MessageErr"] = "Houve um Erro ao Editar o Professor " + professores.NomeCompleto;
                    return RedirectToAction("Index");
                }
            }

            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            ViewData["Countries"] = new SelectList(CombosHelper.GetCursos().Where(m => m.EmailFaculdade == Nomeinst), "CursoId", "NomeCurso", professores.CursoIdUm);
            ViewData["CountriesTwo"] = new SelectList(CombosHelper.GetCursos().Where(m => m.EmailFaculdade == Nomeinst), "CursoId", "NomeCurso", professores.CursoIdDois);

            ViewBag.DisciplinaCinco = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaCinco);
            ViewBag.DisciplinaDois = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaDois);
            ViewBag.DisciplinaQuatro = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaQuatro);
            ViewBag.DisciplinaSeis = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaSeis);
            ViewBag.DisciplinaTres = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaTres);
            ViewBag.DisciplinaUm = new SelectList(CombosHelper.GetDisciplinas().Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", professores.DisciplinaUm);
            return View(professores);
        }

        // GET: Professores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professores professores = db.Professores.Find(id);
            if (professores == null)
            {
                return HttpNotFound();
            }
            return View(professores);
        }

        // POST: Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professores professores = db.Professores.Find(id);
            db.Professores.Remove(professores);
            try
            {
                db.SaveChanges();
                TempData["Message"] = "Professor Deletado com Sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["MessageErr"] = "Houve um Erro ao deletar o Professor: " + professores.NomeCompleto;
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
