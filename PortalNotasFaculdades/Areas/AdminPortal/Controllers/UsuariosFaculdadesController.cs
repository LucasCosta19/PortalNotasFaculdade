using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalNotasFaculdades.Models;
using PortalNotasFaculdades.Areas.AdminPortal.Models;

namespace PortalNotasFaculdades.Areas.AdminPortal.Controllers
{
    public class UsuariosFaculdadesController : Controller
    {
        private PortalContext db = new PortalContext();

        // GET: AdminPortal/UsuariosFaculdades
        public ActionResult Index()
        {
            var Nomeinst = Convert.ToString(Session["EmailFaculdade"]);

            PortalNotasFaculdades.Models.UsuariosFaculdades usuariosFaculdades = db.UsuariosFaculdades.FirstOrDefault(a => a.NomeCompleto == User.Identity.Name);

            return View(db.UsuariosFaculdades.ToList());
        }

        // GET: AdminPortal/UsuariosFaculdades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortalNotasFaculdades.Models.UsuariosFaculdades usuariosFaculdades = db.UsuariosFaculdades.Find(id);
            if (usuariosFaculdades == null)
            {
                return HttpNotFound();
            }
            return View(usuariosFaculdades);
        }

        // GET: AdminPortal/UsuariosFaculdades/Create
        public ActionResult Create()
        {
            List<Faculdades> GetFaculdade()
            {
                var dep = db.Faculdades.ToList();
                dep.Add(new Faculdades
                {
                    FaculdadeId = 0,
                    Nome = "[Selecione uma Faculdade]"
                });
                return dep = dep.OrderBy(d => d.Nome).ToList();
            }
            ViewBag.FaculdadeId = new SelectList(GetFaculdade().OrderBy(m => m.Nome), "FaculdadeId", "Nome");
            ViewBag.EmailFaculdade = new SelectList(db.Faculdades.OrderBy(m => m.Nome), "Email", "Email");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PortalNotasFaculdades.Models.UsuariosFaculdades usuariosFaculdades)
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

        // GET: AdminPortal/UsuariosFaculdades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortalNotasFaculdades.Models.UsuariosFaculdades usuariosFaculdades = db.UsuariosFaculdades.Find(id);
            if (usuariosFaculdades == null)
            {
                return HttpNotFound();
            }
            return View(usuariosFaculdades);
        }

        // POST: AdminPortal/UsuariosFaculdades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioId,NomeUsuario,EmailUsuario,SenhaUsuario,NomeCompleto,DataCadastro,DataUltimoAcesso,Tipo,FaculdadeId,FaculdadeEmail,EmailFaculdade")] PortalNotasFaculdades.Models.UsuariosFaculdades usuariosFaculdades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuariosFaculdades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuariosFaculdades);
        }

        // GET: AdminPortal/UsuariosFaculdades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortalNotasFaculdades.Models.UsuariosFaculdades usuariosFaculdades = db.UsuariosFaculdades.Find(id);
            if (usuariosFaculdades == null)
            {
                return HttpNotFound();
            }
            return View(usuariosFaculdades);
        }

        // POST: AdminPortal/UsuariosFaculdades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PortalNotasFaculdades.Models.UsuariosFaculdades usuariosFaculdades = db.UsuariosFaculdades.Find(id);
            db.UsuariosFaculdades.Remove(usuariosFaculdades);
            db.SaveChanges();
            return RedirectToAction("Index");
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
