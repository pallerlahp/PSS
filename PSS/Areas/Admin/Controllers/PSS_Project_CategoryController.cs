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
    public class PSS_Project_CategoryController : Controller
    {
        private PSSEntities db = new PSSEntities();

        // GET: Admin/PSS_Project_Category
        public async Task<ActionResult> Index()
        {
            return View(await db.PSS_Project_Category.ToListAsync());
        }

        // GET: Admin/PSS_Project_Category/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Project_Category pSS_Project_Category = await db.PSS_Project_Category.FindAsync(id);
            if (pSS_Project_Category == null)
            {
                return HttpNotFound();
            }
            return View(pSS_Project_Category);
        }

        // GET: Admin/PSS_Project_Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PSS_Project_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "proj_category_id,category,active")] PSS_Project_Category pSS_Project_Category)
        {
            if (ModelState.IsValid)
            {
                db.PSS_Project_Category.Add(pSS_Project_Category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pSS_Project_Category);
        }

        // GET: Admin/PSS_Project_Category/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Project_Category pSS_Project_Category = await db.PSS_Project_Category.FindAsync(id);
            if (pSS_Project_Category == null)
            {
                return HttpNotFound();
            }
            return View(pSS_Project_Category);
        }

        // POST: Admin/PSS_Project_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "proj_category_id,category,active")] PSS_Project_Category pSS_Project_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pSS_Project_Category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pSS_Project_Category);
        }

        // GET: Admin/PSS_Project_Category/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Project_Category pSS_Project_Category = await db.PSS_Project_Category.FindAsync(id);
            if (pSS_Project_Category == null)
            {
                return HttpNotFound();
            }
            return View(pSS_Project_Category);
        }

        // POST: Admin/PSS_Project_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PSS_Project_Category pSS_Project_Category = await db.PSS_Project_Category.FindAsync(id);
            db.PSS_Project_Category.Remove(pSS_Project_Category);
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
