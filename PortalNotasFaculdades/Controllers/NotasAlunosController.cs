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
    public class NotasAlunosController : Controller
    {
        private PortalContext db = new PortalContext();

        // GET: NotasAlunos
        public ActionResult Index()
        {
            var tipo = Convert.ToString(Session["Tipo"]);
            var user = Convert.ToString(Session["EmailUsuario"]);
            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);
            var CursoUmInt = Convert.ToInt16(Session["CursoIdUm"]);
            var CursoDoisInt = Convert.ToInt16(Session["CursoIdDois"]);
            var CursoUm = Convert.ToString(Session["CursoIdUm"]);
            var CursoDois = Convert.ToString(Session["CursoIdDois"]);

            //var alunosV = db.Alunos.Where(m => m.EmailFaculdade == Nomeinst && m.CursoId == CursoUmInt || m.CursoId == CursoDoisInt).ToList().FirstOrDefault();

            if (tipo == "Aluno")
            {
                return View(db.NotasAlunos.Where(a => a.Alunos.EmailUsuario == user).ToList());
            }
            if (tipo == "Master")
            {
                return View(db.NotasAlunos.Where(m => m.EmailFaculdade == Nomeinst).ToList());
            }
            if (tipo == "Professor")
            {
                //var alunoCurso = alunosV.CursoId;
                //var StId = Convert.ToString(alunoCurso);
               
                return View(db.NotasAlunos.Where(m => m.EmailFaculdade == Nomeinst && CursoUm.Contains(CursoUm) || CursoDois.Contains(CursoDois)).ToList());
            }
            else
            {
                return View();
            }
        }

        // GET: NotasAlunos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotasAlunos notasAlunos = db.NotasAlunos.Find(id);
            if (notasAlunos == null)
            {
                return HttpNotFound();
            }
            return View(notasAlunos);
        }

        // GET: NotasAlunos/Create
        public ActionResult Create()
        {
            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);
            var CursoUm = Convert.ToInt16(Session["CursoIdUm"]);
            var CursoDois = Convert.ToInt16(Session["CursoIdDois"]);

            var curso = db.Alunos.Where(m => m.EmailFaculdade == Nomeinst).FirstOrDefault();

            var tipo = Convert.ToString(Session["Tipo"]);

            List<Alunos> GetAlunos()
            {
                var dep = db.Alunos.Where(m => m.EmailFaculdade == Nomeinst).ToList();
                dep.Add(new Alunos
                {
                    UsuarioId = 0,
                    NomeCompleto = "[Selecione um Aluno]"
                });
                return dep = dep.OrderBy(d => d.NomeCompleto).ToList();
            }
            List<Alunos> GetAlunosProf()
            {
                var dep = db.Alunos.Where(m => m.EmailFaculdade == Nomeinst && m.CursoId == CursoUm || m.CursoId == CursoDois).ToList();
                dep.Add(new Alunos
                {
                    UsuarioId = 0,
                    NomeCompleto = "[Selecione um Aluno]"
                });
                return dep = dep.OrderBy(d => d.NomeCompleto).ToList();
            }


            if (tipo == "Professor")
            {
                ViewBag.UsuarioId = new SelectList(GetAlunosProf(), "UsuarioId", "NomeCompleto");
            }
            else
            {
                ViewBag.UsuarioId = new SelectList(GetAlunos(), "UsuarioId", "NomeCompleto");
            }

            ViewBag.DisciplinaNota = new SelectList(db.DisciplinasCursos.Where(m => m.EmailFaculdade == Nomeinst && m.NomeDisciplina != "1. Nenhuma").OrderBy(m => m.NomeDisciplina), "DisciplinaId", "NomeDisciplina");
            return View();
        }

        // POST: NotasAlunos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NotasAlunos notasAlunos)
        {
            var verifica = db.NotasAlunos.Where(x => x.UsuarioId == notasAlunos.UsuarioId && x.DisciplinaNota == notasAlunos.DisciplinaNota).FirstOrDefault();

            if (verifica == null)
            {
                if (ModelState.IsValid)
                {
                    db.NotasAlunos.Add(notasAlunos);
                    db.SaveChanges();
                    TempData["Message"] = "Nota Lançada com Sucesso!";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["MessageErr"] = "Já Existe uma Nota Cadastrada para este Aluno com Essa Disciplina: " + verifica.DisciplinasCursos.NomeDisciplina + ". Escolha Outra!!";
                return RedirectToAction("Index");
            }

            var Nomeinst = Convert.ToString(Session["EmailInstituicao"]);

            ViewBag.UsuarioId = new SelectList(db.Alunos.Where(m => m.EmailFaculdade == Nomeinst), "UsuarioId", "NomeCompleto", notasAlunos.UsuarioId);
            ViewBag.DisciplinaNota = new SelectList(db.DisciplinasCursos.Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", notasAlunos.DisciplinaNota);
            return View(notasAlunos);
        }

        // GET: NotasAlunos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotasAlunos notasAlunos = db.NotasAlunos.Find(id);
            if (notasAlunos == null)
            {
                return HttpNotFound();
            }

            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            ViewBag.UsuarioId = new SelectList(db.Alunos.Where(m => m.EmailFaculdade == Nomeinst), "UsuarioId", "NomeCompleto", notasAlunos.UsuarioId);
            ViewBag.DisciplinaNota = new SelectList(db.DisciplinasCursos.Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", notasAlunos.DisciplinaNota);
            return View(notasAlunos);
        }

        // POST: NotasAlunos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NotasAlunos notasAlunos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notasAlunos).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    TempData["Message"] = "Nota Lançada com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["MessageErr"] = "Houve um Erro na Nota a ser Lançada para o Aluno " + notasAlunos.Alunos.NomeCompleto;
                    return RedirectToAction("Index");
                }
            }

            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            ViewBag.UsuarioId = new SelectList(db.Alunos.Where(m => m.EmailFaculdade == Nomeinst), "UsuarioId", "NomeCompleto", notasAlunos.UsuarioId);
            ViewBag.DisciplinaNota = new SelectList(db.DisciplinasCursos.Where(m => m.EmailFaculdade == Nomeinst), "DisciplinaId", "NomeDisciplina", notasAlunos.DisciplinaNota);
            return View(notasAlunos);
        }

        // GET: NotasAlunos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotasAlunos notasAlunos = db.NotasAlunos.Find(id);
            if (notasAlunos == null)
            {
                return HttpNotFound();
            }
            return View(notasAlunos);
        }

        // POST: NotasAlunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NotasAlunos notasAlunos = db.NotasAlunos.Find(id);
            db.NotasAlunos.Remove(notasAlunos);
            try
            {
                db.SaveChanges();
                TempData["Message"] = "Nota Deletada com Sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["MessageErr"] = "Houve um Erro ao Deletar a Nota do Aluno " + notasAlunos.Alunos.NomeCompleto;
                return RedirectToAction("Index");
            }
        }

        public ActionResult _BuscaNota(string disciplina)
        {
            var user = Convert.ToString(Session["EmailUsuario"]);

            var busca = db.NotasAlunos.Where(a => a.DisciplinasCursos.NomeDisciplina.Contains(disciplina) && a.Alunos.EmailUsuario == user).FirstOrDefault();
            try
            {
                TempData["busca"] = busca.DisciplinasCursos.NomeDisciplina;
                return View(busca);
            }
            catch (Exception)
            {
                TempData["buscaErr"] = "Nenhuma Nota Lançada com os Dados Informados!!";
                return RedirectToAction("Index");
            }
        }

        public ActionResult _BuscaNotaSemestre(string semestre)
        {
            var user = Convert.ToString(Session["EmailUsuario"]);

            var busca = db.NotasAlunos.Where(a => a.DisciplinasCursos.SemestreDisciplina == semestre && a.Alunos.EmailUsuario == user).FirstOrDefault();
            try
            {
                TempData["busca"] = busca.DisciplinasCursos.NomeDisciplina;
                return View(busca);
            }
            catch (Exception)
            {
                TempData["buscaErr"] = "Nenhuma Nota Lançada com os Dados Informados!!";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Teste() {
            return View();
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
