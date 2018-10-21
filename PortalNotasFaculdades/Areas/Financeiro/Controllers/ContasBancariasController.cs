using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalNotasFaculdades.Areas.Financeiro.Models;
using PortalNotasFaculdades.Models;

namespace PortalNotasFaculdades.Areas.Financeiro.Controllers
{
    public class ContasBancariasController : Controller
    {
        private PortalContext db = new PortalContext();

        // GET: Financeiro/ContasBancarias
        public ActionResult Index()
        {
            return View(db.ContasBancarias.ToList());
        }

        // GET: Financeiro/ContasBancarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasBancarias contasBancarias = db.ContasBancarias.Find(id);
            if (contasBancarias == null)
            {
                return HttpNotFound();
            }
            return View(contasBancarias);
        }

        // GET: Financeiro/ContasBancarias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Financeiro/ContasBancarias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContaBancariaId,NomeBanco,NomeProprietario,NumeroConta,Agencia,SaldoInicial,DataSaldoInicial,SaldoAtual,DataInsercao")] ContasBancarias contasBancarias)
        {
            if (ModelState.IsValid)
            {
                db.ContasBancarias.Add(contasBancarias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contasBancarias);
        }

        // GET: Financeiro/ContasBancarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasBancarias contasBancarias = db.ContasBancarias.Find(id);
            if (contasBancarias == null)
            {
                return HttpNotFound();
            }
            return View(contasBancarias);
        }

        // POST: Financeiro/ContasBancarias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContaBancariaId,NomeBanco,NomeProprietario,NumeroConta,Agencia,SaldoInicial,DataSaldoInicial,SaldoAtual,DataInsercao")] ContasBancarias contasBancarias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contasBancarias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contasBancarias);
        }

        // GET: Financeiro/ContasBancarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasBancarias contasBancarias = db.ContasBancarias.Find(id);
            if (contasBancarias == null)
            {
                return HttpNotFound();
            }
            return View(contasBancarias);
        }

        // POST: Financeiro/ContasBancarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContasBancarias contasBancarias = db.ContasBancarias.Find(id);
            db.ContasBancarias.Remove(contasBancarias);
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
