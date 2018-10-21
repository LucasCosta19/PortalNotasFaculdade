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
    public class UsuariosFaculdadesController : Controller
    {
        private PortalContext db = new PortalContext();

        // GET: UsuariosFaculdades
        public ActionResult Index()
        {
            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            UsuariosFaculdades usuariosFaculdades = db.UsuariosFaculdades.FirstOrDefault(a => a.NomeCompleto == User.Identity.Name);

            return View(db.UsuariosFaculdades.Where(a => a.EmailFaculdade == Nomeinst).ToList());
        }

        // GET: UsuariosFaculdades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosFaculdades usuariosFaculdades = db.UsuariosFaculdades.Find(id);
            if (usuariosFaculdades == null)
            {
                return HttpNotFound();
            }
            return View(usuariosFaculdades);
        }

        // GET: UsuariosFaculdades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosFaculdades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuariosFaculdades usuariosFaculdades)
        {
            if (ModelState.IsValid)
            {
                db.UsuariosFaculdades.Add(usuariosFaculdades);
                try
                {
                    db.SaveChanges();
                    TempData["Message"] = "Usuário Cadastrado com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["MessageErr"] = "Houve um Erro ao Cadastrar o Usuário!";
                    return RedirectToAction("Index");
                }
            }

            return View(usuariosFaculdades);
        }

        // GET: UsuariosFaculdades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosFaculdades usuariosFaculdades = db.UsuariosFaculdades.Find(id);
            if (usuariosFaculdades == null)
            {
                return HttpNotFound();
            }
            return View(usuariosFaculdades);
        }

        // POST: UsuariosFaculdades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuariosFaculdades usuariosFaculdades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuariosFaculdades).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    TempData["Message"] = "Usuário Editado com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["MessageErr"] = "Houve um Erro ao Editar o Usuário: " + usuariosFaculdades.NomeCompleto;
                    return RedirectToAction("Index");
                }               
            }
            return View(usuariosFaculdades);
        }

        // GET: UsuariosFaculdades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosFaculdades usuariosFaculdades = db.UsuariosFaculdades.Find(id);
            if (usuariosFaculdades == null)
            {
                return HttpNotFound();
            }
            return View(usuariosFaculdades);
        }

        // POST: UsuariosFaculdades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuariosFaculdades usuariosFaculdades = db.UsuariosFaculdades.Find(id);
            db.UsuariosFaculdades.Remove(usuariosFaculdades);
            try
            {
                db.SaveChanges();
                TempData["Message"] = "Usuário Deletado com Sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["MessageErr"] = "Houve um Erro ao Deletar o Usuário: " + usuariosFaculdades.NomeCompleto;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Faculdade()
        {
            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            return View(db.Faculdades.Where(m => m.Email == Nomeinst).ToList());
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
