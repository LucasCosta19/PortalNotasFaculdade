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
    public class AlunosController : Controller
    {
        private PortalContext db = new PortalContext();

        // GET: Alunos
        public ActionResult Index()
        {
            var tipo = Convert.ToString(Session["Tipo"]);
            var user = Convert.ToString(Session["EmailUsuario"]);
            var inst = Convert.ToString(Session["FaculdadeId"]);
            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            Alunos alunosPortal = db.Alunos.FirstOrDefault(a => a.NomeCompleto == User.Identity.Name);

            if (tipo == "Master")
            {
                return View(db.Alunos.Where(m => m.EmailFaculdade == Nomeinst).ToList());
            }

            if (tipo == "Aluno")
            {
                return View(db.Alunos.Where(a => a.EmailUsuario == user).ToList());
            }

            if (tipo == "Professor")
            {
                return View();
            }
            else
            {
                return View();
            }
        }

        // GET: Alunos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos alunos = db.Alunos.Find(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }
            return View(alunos);
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {
            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            ViewBag.CursoId = new SelectList(db.Cursos.Where(m => m.EmailFaculdade == Nomeinst).OrderBy(m => m.NomeCurso), "CursoId", "NomeCurso");
            return View();
        }

        // POST: Alunos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Alunos alunos)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(alunos);
                try
                {
                    db.SaveChanges();
                    TempData["Message"] = "Aluno Inserido com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["MessageErr"] = "Houve um Erro! E-Mail ou CPF Duplicados!!!";
                    return RedirectToAction("Index");
                }
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "NomeCurso", alunos.CursoId);
            return View(alunos);
        }

        // GET: Alunos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos alunos = db.Alunos.Find(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "NomeCurso", alunos.CursoId);
            return View(alunos);
        }

        // POST: Alunos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Alunos alunos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunos).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    TempData["Message"] = "Aluno Editado com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["MessageErr"] = "Houve um Erro ao Editar o Aluno " + alunos.NomeCompleto;
                    return RedirectToAction("Index");

                }
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "CursoId", "NomeCurso", alunos.CursoId);
            return View(alunos);
        }

        // GET: Alunos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos alunos = db.Alunos.Find(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }
            return View(alunos);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alunos alunos = db.Alunos.Find(id);
            db.Alunos.Remove(alunos);
            try {                
                db.SaveChanges();
                TempData["Message"] = "Aluno Deletado com Sucesso!";
                return RedirectToAction("Index");
            } catch(Exception) {
                TempData["MessageErr"] = "Houve um Erro ao Deletar o Aluno " + alunos.NomeCompleto;
                return RedirectToAction("Index");
            }                 
        }

        public ActionResult _BuscaAluno(string nomeOrcpf)
        {
            var busca = db.Alunos.Where(a => a.NomeCompleto.Contains(nomeOrcpf) || a.CpfUsuario.Contains(nomeOrcpf)).FirstOrDefault();
            try
            {
                TempData["busca"] = busca.NomeCompleto;
                return View(busca);
            }
            catch (Exception)
            {
                TempData["buscaErr"] = "Houve um Erro ao Buscar o Aluno com os Dados Informados. Use o campo de busca abaixo!";
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
