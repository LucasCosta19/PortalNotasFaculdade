using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalNotasFaculdades.Areas.AdminPortal.Models;
using PortalNotasFaculdades.Models;

namespace PortalNotasFaculdades.Areas.AdminPortal.Controllers
{
    public class UsuariosAdminController : Controller
    {
        private PortalContext db = new PortalContext();

        // GET: AdminPortal/UsuariosAdmin
        public ActionResult Index()
        {
            return View(db.UsuariosAdmin.ToList());
        }

        // GET: AdminPortal/UsuariosAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosAdmin usuariosAdmin = db.UsuariosAdmin.Find(id);
            if (usuariosAdmin == null)
            {
                return HttpNotFound();
            }
            return View(usuariosAdmin);
        }

        // GET: AdminPortal/UsuariosAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPortal/UsuariosAdmin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuariosAdmin usuariosAdmin)
        {
            if (ModelState.IsValid)
            {
                db.UsuariosAdmin.Add(usuariosAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuariosAdmin);
        }

        // GET: AdminPortal/UsuariosAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosAdmin usuariosAdmin = db.UsuariosAdmin.Find(id);
            if (usuariosAdmin == null)
            {
                return HttpNotFound();
            }
            return View(usuariosAdmin);
        }

        // POST: AdminPortal/UsuariosAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuariosAdmin usuariosAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuariosAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuariosAdmin);
        }

        // GET: AdminPortal/UsuariosAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosAdmin usuariosAdmin = db.UsuariosAdmin.Find(id);
            if (usuariosAdmin == null)
            {
                return HttpNotFound();
            }
            return View(usuariosAdmin);
        }

        // POST: AdminPortal/UsuariosAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuariosAdmin usuariosAdmin = db.UsuariosAdmin.Find(id);
            db.UsuariosAdmin.Remove(usuariosAdmin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login() {
            return View();
        }

        [HttpPost]        
        [ValidateAntiForgeryToken]
        public ActionResult Authorize(UsuariosAdmin adminPortal) {
            using (PortalContext db = new PortalContext()) {
                var verifica = db.UsuariosAdmin.Where(a => a.Email == adminPortal.Email && a.Senha == adminPortal.Senha).FirstOrDefault();

                if (verifica != null) {
                    Session["AdminId"] = verifica.AdminId;
                    Session["Email"] = verifica.Email;
                    Session["Nome"] = verifica.Nome;
                    return RedirectToAction("Index", "Home");
                } else {
                    Response.Write("<script>alert('Usuário ou Senha não encontrados!')</script>");
                    return View("Login");
                }
            }
        }

        public ActionResult LogOut() {
            int userId = (int)Session["AdminId"];
            Session.Abandon();
            return RedirectToAction("Login", "UsuariosAdmin");
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
