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
    public class FaculdadesController : Controller
    {
        private PortalContext db = new PortalContext();

        // GET: AdminPortal/Faculdades
        public ActionResult Index()
        {
            return View(db.Faculdades.ToList());
        }

        // GET: AdminPortal/Faculdades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculdades faculdades = db.Faculdades.Find(id);
            if (faculdades == null)
            {
                return HttpNotFound();
            }
            return View(faculdades);
        }

        // GET: AdminPortal/Faculdades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPortal/Faculdades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FaculdadeId,Nome,TipoPessoa,Cpf,Cnpj,Telefone,Email,Estado,Cidade,Endereco,Cep")] Faculdades faculdades)
        {
            if (ModelState.IsValid)
            {
                db.Faculdades.Add(faculdades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faculdades);
        }

        // GET: AdminPortal/Faculdades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculdades faculdades = db.Faculdades.Find(id);
            if (faculdades == null)
            {
                return HttpNotFound();
            }
            return View(faculdades);
        }

        // POST: AdminPortal/Faculdades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FaculdadeId,Nome,TipoPessoa,Cpf,Cnpj,Telefone,Email,Estado,Cidade,Endereco,Cep")] Faculdades faculdades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculdades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faculdades);
        }

        // GET: AdminPortal/Faculdades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculdades faculdades = db.Faculdades.Find(id);
            if (faculdades == null)
            {
                return HttpNotFound();
            }
            return View(faculdades);
        }

        // POST: AdminPortal/Faculdades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculdades faculdades = db.Faculdades.Find(id);
            db.Faculdades.Remove(faculdades);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Busca Faculdade
        public ActionResult _BuscaFaculdade(string nome) {
            var busca = db.Faculdades.Where(a => a.Nome.Contains(nome)).FirstOrDefault();

            try {
                TempData["busca"] = busca.Nome;
                return View(busca);
            } catch (Exception) {
                TempData["buscaErr"] = "Houve um Erro ao Buscar a Faculdade com os Dados Informados. Use o campo de busca abaixo!";
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
