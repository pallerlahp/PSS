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

namespace PSS.Areas.Professor
{
    public class PSS_ProjectsController : Controller
    {
        private PSSEntities db = new PSSEntities();

        // GET: Professor/PSS_Projects
        public async Task<ActionResult> Index()
        {
            var pSS_Projects = db.PSS_Projects.Include(p => p.PSS_Project_Category).Include(p => p.PSS_Status).Include(p => p.PSS_Users);
            return View(await pSS_Projects.ToListAsync());
        }

	   // GET: Professor/PSS_Projects
	    [HttpGet]
	   public async Task<ActionResult> IndexView(string projectCategory)
	   {
		   var selectedProjectCategories = projectCategory.Split(',').ToList();
		   var pSS_Projects = db.PSS_Projects.Include(p => p.PSS_Project_Category).Include(p => p.PSS_Status).Include(p => p.PSS_Users).Where(p => selectedProjectCategories.Contains(p.proj_category_id.ToString()));
		   return View("Index",await pSS_Projects.ToListAsync());
	   }
	    [HttpPost]
	   public async Task<ActionResult> IndexView(string ProjectIds, string other)
	    {
		    var selectedProjectCategories = ProjectIds.Split(',').ToList();
		    var pSS_Projects = db.PSS_Projects.Include(p => p.PSS_Project_Category).Include(p => p.PSS_Status).Include(p => p.PSS_Users).Include(p => p.PSS_Student_Project).Where(p => selectedProjectCategories.Contains(p.project_id.ToString()));

            return RedirectToAction("Details", "PSS_Projects", new { id = ProjectIds });
            //return View("Details",pSS_Projects);
	    }

	   //[HttpPost]
	   //[ValidateAntiForgeryToken]
	   //public async Task<ActionResult> IndexView(IEnumerable<PSS.Models.PSS_Projects> projects)
	   //{
	   //	//var selectedProjects = projects.Where(project => Request.Form[project.project_id]==true)
	   //	//var pSS_Projects = db.PSS_Projects.Include(p => p.PSS_Project_Category).Include(p => p.PSS_Status).Include(p => p.PSS_Users).Where(p => selectedProjectCategories.Contains(p.proj_category_id.ToString()));
	   //	return View(await pSS_Projects.ToListAsync());
	   //}

        // GET: Professor/PSS_Projects/Details/5
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

        // GET: Professor/PSS_Projects/Create
        public ActionResult Create()
        {
		  ViewBag.proj_category_id = new SelectList(db.PSS_Project_Category, "proj_category_id", "category");
            ViewBag.project_status_id = new SelectList(db.PSS_Status, "status_id", "status");
            ViewBag.user_id = new SelectList(db.PSS_Users, "user_id", "first_name");
            ViewBag.sponsor_id = new SelectList(db.PSS_Sponsor, "sponsor_id", "sponsor_name");
            return View();
        }

        // POST: Professor/PSS_Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "project_id,project_title,description,proj_category_id,project_status_id,extra_details,dept_organisation,material_budget,preferred_major,user_id")] PSS_Projects pSS_Projects)
        {
            if (ModelState.IsValid)
            {
                db.PSS_Projects.Add(pSS_Projects);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.proj_category_id = new SelectList(db.PSS_Project_Category, "proj_category_id", "category", pSS_Projects.proj_category_id);
            ViewBag.project_status_id = new SelectList(db.PSS_Status, "status_id", "status", pSS_Projects.project_status_id);
            ViewBag.user_id = new SelectList(db.PSS_Users, "user_id", "first_name", pSS_Projects.user_id);
            return View(pSS_Projects);
        }

        // GET: Professor/PSS_Projects/Edit/5
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
            ViewBag.project_status_id = new SelectList(db.PSS_Status, "status_id", "status", pSS_Projects.project_status_id);
            ViewBag.user_id = new SelectList(db.PSS_Users, "user_id", "first_name", pSS_Projects.user_id);
            return View(pSS_Projects);
        }

        // POST: Professor/PSS_Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "project_id,project_title,description,proj_category_id,project_status_id,extra_details,dept_organisation,material_budget,preferred_major,user_id")] PSS_Projects pSS_Projects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pSS_Projects).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.proj_category_id = new SelectList(db.PSS_Project_Category, "proj_category_id", "category", pSS_Projects.proj_category_id);
            ViewBag.project_status_id = new SelectList(db.PSS_Status, "status_id", "status", pSS_Projects.project_status_id);
            ViewBag.user_id = new SelectList(db.PSS_Users, "user_id", "first_name", pSS_Projects.user_id);
            return View(pSS_Projects);
        }

        // GET: Professor/PSS_Projects/Delete/5
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

        // POST: Professor/PSS_Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PSS_Student_Project pSS_Student_Project = new PSS_Student_Project();
            PSS_Projects pSS_Projects = await db.PSS_Projects.FindAsync(id);
            if (ModelState.IsValid)
            {
                int user_id = 1;
                if(Session["user_id"]!=null)
                {
                    user_id = Convert.ToInt32(Session["user_id"].ToString());
                }
                pSS_Student_Project.student_id = user_id;
                pSS_Student_Project.project_id = pSS_Projects.project_id;                
                pSS_Student_Project.requested_date = DateTime.Now;
                pSS_Student_Project.project_request_status_id = 5;

                pSS_Student_Project.file_name = "Test.docx";
                //pSS_Student_Project.document = new byte[pSS_Student_Project.documentData.ContentLength];
                //pSS_Student_Project.documentData.InputStream.Read(pSS_Student_Project.document, 0, pSS_Student_Project.document.Length);
                db.PSS_Student_Project.Add(pSS_Student_Project);
                await db.SaveChangesAsync();
                return RedirectToAction("AppliedProjects", "PSS_Student_Project");
            }
            
            //PSS_Projects pSS_Projects = await db.PSS_Projects.FindAsync(id);
            //db.PSS_Projects.Remove(pSS_Projects);
            //await db.SaveChangesAsync();
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
