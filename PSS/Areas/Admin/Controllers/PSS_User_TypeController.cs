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
    public class PSS_User_TypeController : Controller
    {
        private PSSEntities db = new PSSEntities();

        // GET: Admin/PSS_User_Type
        public async Task<ActionResult> Index()
        {
            return View(await db.PSS_User_Type.ToListAsync());
        }

        // GET: Admin/PSS_User_Type/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_User_Type pSS_User_Type = await db.PSS_User_Type.FindAsync(id);
            if (pSS_User_Type == null)
            {
                return HttpNotFound();
            }
            return View(pSS_User_Type);
        }

        // GET: Admin/PSS_User_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PSS_User_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "user_type_id,type,active")] PSS_User_Type pSS_User_Type)
        {
            if (ModelState.IsValid)
            {
                db.PSS_User_Type.Add(pSS_User_Type);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pSS_User_Type);
        }

        // GET: Admin/PSS_User_Type/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_User_Type pSS_User_Type = await db.PSS_User_Type.FindAsync(id);
            if (pSS_User_Type == null)
            {
                return HttpNotFound();
            }
            return View(pSS_User_Type);
        }

        // POST: Admin/PSS_User_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "user_type_id,type,active")] PSS_User_Type pSS_User_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pSS_User_Type).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pSS_User_Type);
        }

        // GET: Admin/PSS_User_Type/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_User_Type pSS_User_Type = await db.PSS_User_Type.FindAsync(id);
            if (pSS_User_Type == null)
            {
                return HttpNotFound();
            }
            return View(pSS_User_Type);
        }

        // POST: Admin/PSS_User_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PSS_User_Type pSS_User_Type = await db.PSS_User_Type.FindAsync(id);
            db.PSS_User_Type.Remove(pSS_User_Type);
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
