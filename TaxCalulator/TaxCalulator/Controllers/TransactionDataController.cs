using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaxCalulator.DAL;
using TaxCalulator.Models;

namespace TaxCalulator.Controllers
{
    public class TransactionDataController : Controller
    {
        private TransactinDataContext db = new TransactinDataContext();

        // GET: TransactionData
        public ActionResult Index()
        {
            return View(db.TransactionsData.ToList());
        }

        // GET: TransactionData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionData transactionData = db.TransactionsData.Find(id);
            if (transactionData == null)
            {
                return HttpNotFound();
            }
            return View(transactionData);
        }

        // GET: TransactionData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Account,Description,CurrencyCode,Amount")] TransactionData transactionData)
        {
            if (ModelState.IsValid)
            {
                db.TransactionsData.Add(transactionData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transactionData);
        }

        // GET: TransactionData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionData transactionData = db.TransactionsData.Find(id);
            if (transactionData == null)
            {
                return HttpNotFound();
            }
            return View(transactionData);
        }

        // POST: TransactionData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Account,Description,CurrencyCode,Amount")] TransactionData transactionData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactionData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transactionData);
        }

        // GET: TransactionData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionData transactionData = db.TransactionsData.Find(id);
            if (transactionData == null)
            {
                return HttpNotFound();
            }
            return View(transactionData);
        }

        // POST: TransactionData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransactionData transactionData = db.TransactionsData.Find(id);
            db.TransactionsData.Remove(transactionData);
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
