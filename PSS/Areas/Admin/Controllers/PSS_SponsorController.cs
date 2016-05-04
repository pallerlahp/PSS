using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PSS.Models;

namespace PSS.Areas.Admin.Controllers
{
    public class PSS_SponsorController : Controller
    {
        private PSSEntities db = new PSSEntities();

        // GET: Admin/PSS_Sponsor
        public async Task<ActionResult> Index()
        {
            return View(await db.PSS_Sponsor.ToListAsync());
        }

        // GET: Admin/PSS_Sponsor/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Sponsor pSS_Sponsor = await db.PSS_Sponsor.FindAsync(id);
            if (pSS_Sponsor == null)
            {
                return HttpNotFound();
            }
            return View(pSS_Sponsor);
        }

        // GET: Admin/PSS_Sponsor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PSS_Sponsor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "sponsor_id,sponsor_name,active")] PSS_Sponsor pSS_Sponsor)
        {
            if (ModelState.IsValid)
            {
                db.PSS_Sponsor.Add(pSS_Sponsor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pSS_Sponsor);
        }

        // GET: Admin/PSS_Sponsor/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Sponsor pSS_Sponsor = await db.PSS_Sponsor.FindAsync(id);
            if (pSS_Sponsor == null)
            {
                return HttpNotFound();
            }
            return View(pSS_Sponsor);
        }

        // POST: Admin/PSS_Sponsor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "sponsor_id,sponsor_name,active")] PSS_Sponsor pSS_Sponsor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pSS_Sponsor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pSS_Sponsor);
        }

        // GET: Admin/PSS_Sponsor/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Sponsor pSS_Sponsor = await db.PSS_Sponsor.FindAsync(id);
            if (pSS_Sponsor == null)
            {
                return HttpNotFound();
            }
            return View(pSS_Sponsor);
        }

        // POST: Admin/PSS_Sponsor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PSS_Sponsor pSS_Sponsor = await db.PSS_Sponsor.FindAsync(id);
            db.PSS_Sponsor.Remove(pSS_Sponsor);
            await db.SaveChangesAsync();
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
