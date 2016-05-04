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

namespace PSS.Areas.Sponsor.Controllers
{
    public class PSS_ProjectsController : Controller
    {
        private PSSEntities db = new PSSEntities();

        // GET: Sponsor/PSS_Projects
        public async Task<ActionResult> Index()
        {
            var pSS_Projects = db.PSS_Projects.Include(p => p.PSS_Project_Category).Include(p => p.PSS_Sponsor).Include(p => p.PSS_Status).Include(p => p.PSS_Users);
            return View(await pSS_Projects.ToListAsync());
        }

        // GET: Sponsor/PSS_Projects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Projects pSS_Projects = await db.PSS_Projects.FindAsync(id);
            if (pSS_Projects == null)
            {
                return HttpNotFound();
            }
            return View(pSS_Projects);
        }

        // GET: Sponsor/PSS_Projects/Create
        public ActionResult Create()
        {
            ViewBag.proj_category_id = new SelectList(db.PSS_Project_Category, "proj_category_id", "category");
            ViewBag.sponsor_id = new SelectList(db.PSS_Sponsor, "sponsor_id", "sponsor_name");
            ViewBag.project_status_id = new SelectList(db.PSS_Status, "status_id", "status");
            ViewBag.user_id = new SelectList(db.PSS_Users, "user_id", "first_name");
            return View();
        }

        // POST: Sponsor/PSS_Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "project_id,project_title,description,proj_category_id,project_status_id,extra_details,sponsor_id,material_budget,preferred_major,user_id,project_created_date,project_selection_closing_date,active")] PSS_Projects pSS_Projects)
        {
            if (ModelState.IsValid)
            {
                db.PSS_Projects.Add(pSS_Projects);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.proj_category_id = new SelectList(db.PSS_Project_Category, "proj_category_id", "category", pSS_Projects.proj_category_id);
            ViewBag.sponsor_id = new SelectList(db.PSS_Sponsor, "sponsor_id", "sponsor_name", pSS_Projects.sponsor_id);
            ViewBag.project_status_id = new SelectList(db.PSS_Status, "status_id", "status", pSS_Projects.project_status_id);
            ViewBag.user_id = new SelectList(db.PSS_Users, "user_id", "first_name", pSS_Projects.user_id);
            return View(pSS_Projects);
        }

        // GET: Sponsor/PSS_Projects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Projects pSS_Projects = await db.PSS_Projects.FindAsync(id);
            if (pSS_Projects == null)
            {
                return HttpNotFound();
            }
            ViewBag.proj_category_id = new SelectList(db.PSS_Project_Category, "proj_category_id", "category", pSS_Projects.proj_category_id);
            ViewBag.sponsor_id = new SelectList(db.PSS_Sponsor, "sponsor_id", "sponsor_name", pSS_Projects.sponsor_id);
            ViewBag.project_status_id = new SelectList(db.PSS_Status, "status_id", "status", pSS_Projects.project_status_id);
            ViewBag.user_id = new SelectList(db.PSS_Users, "user_id", "first_name", pSS_Projects.user_id);
            return View(pSS_Projects);
        }

        // POST: Sponsor/PSS_Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "project_id,project_title,description,proj_category_id,project_status_id,extra_details,sponsor_id,material_budget,preferred_major,user_id,project_created_date,project_selection_closing_date,active")] PSS_Projects pSS_Projects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pSS_Projects).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.proj_category_id = new SelectList(db.PSS_Project_Category, "proj_category_id", "category", pSS_Projects.proj_category_id);
            ViewBag.sponsor_id = new SelectList(db.PSS_Sponsor, "sponsor_id", "sponsor_name", pSS_Projects.sponsor_id);
            ViewBag.project_status_id = new SelectList(db.PSS_Status, "status_id", "status", pSS_Projects.project_status_id);
            ViewBag.user_id = new SelectList(db.PSS_Users, "user_id", "first_name", pSS_Projects.user_id);
            return View(pSS_Projects);
        }

        // GET: Sponsor/PSS_Projects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Projects pSS_Projects = await db.PSS_Projects.FindAsync(id);
            if (pSS_Projects == null)
            {
                return HttpNotFound();
            }
            return View(pSS_Projects);
        }

        // POST: Sponsor/PSS_Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PSS_Projects pSS_Projects = await db.PSS_Projects.FindAsync(id);
            db.PSS_Projects.Remove(pSS_Projects);
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
