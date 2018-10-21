using PortalNotas.Classes;
using PortalNotasFaculdades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PortalNotas.Controllers
{
    public class SampleController : Controller
    {
        private PortalContext db = new PortalContext();

        // GET: Sample
        public ActionResult Index()
        {                            
            ViewData["Countries"] = new SelectList(CombosHelper.GetCursos(), "CursoId", "NomeCurso");
            return View();
        }

        public JsonResult States(int Country) {
            List<int> StatesList = new List<int>();

            var aluno = db.Alunos.Where(m => m.UsuarioId == Country).FirstOrDefault();

            var result = (db.DisciplinasCursos.AsNoTracking().Where(a => a.CursoId == aluno.CursoId && a.NomeDisciplina != "1. Nenhuma")).OrderBy(a => a.NomeDisciplina);

            if(result != null) {
                var novoR = Convert.ToString(result);                

                return Json(new SelectList(result, "DisciplinaId", "NomeDisciplina"), JsonRequestBehavior.AllowGet);                
            }

            return Json(false);
        }

        public JsonResult States2(int Country) {
            List<int> StatesList = new List<int>();

            var result = (db.Cursos.AsNoTracking().Where(a => a.CursoId == Country)).OrderBy(a => a.NomeCurso);

            if (result != null) {
                var novoR = Convert.ToString(result);                

                return Json(new SelectList(result, "CursoId", "NomeCurso"), JsonRequestBehavior.AllowGet);                
            }

            return Json(false);
        }

        public JsonResult States3(int Country)
        {
            List<int> StatesList = new List<int>();

            var result = (db.DisciplinasCursos.AsNoTracking().Where(a => a.CursoId == Country)).OrderBy(a => a.NomeDisciplina);

            if (result != null)
            {
                var novoR = Convert.ToString(result);

                return Json(new SelectList(result, "DisciplinaId", "NomeDisciplina"), JsonRequestBehavior.AllowGet);
            }

            return Json(false);
        }

        public JsonResult Faculdades(int Country)
        {
            List<int> StatesList = new List<int>();

            var result = (db.Faculdades.AsNoTracking().Where(a => a.FaculdadeId == Country)).OrderBy(a => a.Email);

            if (result != null) {
                var novoR = Convert.ToString(result);

                return Json(new SelectList(result, "Email", "Email"), JsonRequestBehavior.AllowGet);
            }

            return Json(false);
        }

    }
}