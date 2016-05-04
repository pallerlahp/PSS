using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PSS.Models;

namespace PSS.Areas.Professor
{
    public class PSS_Student_ProjectController : Controller
    {
        private PSSEntities db = new PSSEntities();

        // GET: Professor/PSS_Student_Project
        public async Task<ActionResult> Index()
        {
		   //var pSS_Student_Project = db.PSS_Student_Project.Include(p => p.PSS_Projects).Include(p => p.PSS_Status).Include(p => p.PSS_Users).Where(p => p.PSS_Status.type == false && p.PSS_Status.status.Equals("Requested")).Where(p=>p.student_id.Equals(1));
            var pSS_Student_Project = db.PSS_Student_Project;
            return View(await pSS_Student_Project.ToListAsync());
        }

	   public async Task<ActionResult> IndexView()
	   {
		   string selectedProjectCategory = Request.Form["proj_category_id"];
		   return RedirectToAction("IndexView", "PSS_Projects", new { projectCategory = selectedProjectCategory });
	   }

       // GET: Professor/PSS_Student_Project/Details/5
       public ActionResult AppliedProjects()
       {

           if (Session["user_id"] != null)
           {

               int user_id = Convert.ToInt32(Session["user_id"].ToString());


               var pSS_Student_Project = db.PSS_Student_Project.Where(p => p.student_id == user_id);
               if (pSS_Student_Project == null)
               {
                   return HttpNotFound();
               }
               return View("Index", pSS_Student_Project.ToList());
           }
           else
           {
               var pSS_Student_Project = db.PSS_Student_Project;
               if (pSS_Student_Project == null)
               {
                   return HttpNotFound();
               }
               return View("Index", pSS_Student_Project.ToList());
               //return HttpNotFound();
           }
       }

        // GET: Professor/PSS_Student_Project/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Student_Project pSS_Student_Project = await db.PSS_Student_Project.FindAsync(id);
            if (pSS_Student_Project == null)
            {
                return HttpNotFound();
            }
            return View(pSS_Student_Project);
        }

        // GET: Professor/PSS_Student_Project/Create
        public ActionResult Create()
	   {
		   ViewBag.proj_category_id = new MultiSelectList(db.PSS_Project_Category, "proj_category_id", "category");
           ViewBag.project_id = new SelectList(db.PSS_Projects.Where(p => p.PSS_Status.type == true && p.PSS_Status.status.Equals("Available")), "project_id", "project_title");
           ViewBag.project_request_status_id = new SelectList(db.PSS_Status, "status_id", "status");
           ViewBag.student_id = new SelectList(db.PSS_Users, "user_id", "user_id");
            
		   return View();
        }

        // POST: Professor/PSS_Student_Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "project_request_id,student_id,project_id,requested_date,project_request_status_id,document,documentData,proj_category_id")] PSS_Student_Project pSS_Student_Project)
        {
		  //if (ModelState.IsValid)
		  //{
		  //    pSS_Student_Project.requested_date = DateTime.Now;

		  //    pSS_Student_Project.file_name = pSS_Student_Project.documentData.FileName;
		  //    pSS_Student_Project.document = new byte[pSS_Student_Project.documentData.ContentLength];
		  //    pSS_Student_Project.documentData.InputStream.Read(pSS_Student_Project.document, 0, pSS_Student_Project.document.Length);
		  //    db.PSS_Student_Project.Add(pSS_Student_Project);
		  //    await db.SaveChangesAsync();
		  //    return RedirectToAction("Index");
		  //}

		  //ViewBag.project_id = new SelectList(db.PSS_Projects, "project_id", "project_title", pSS_Student_Project.project_id);
		  //ViewBag.project_request_status_id = new SelectList(db.PSS_Status, "status_id", "status", pSS_Student_Project.project_request_status_id);
		  //ViewBag.student_id = new SelectList(db.PSS_Users, "user_id", "password", pSS_Student_Project.student_id);
		  //return View(pSS_Student_Project);
		   string selectedProjectCategory = Request.Form["proj_category_id"];
		   return RedirectToAction("IndexView", "PSS_Projects", new { projectCategory = selectedProjectCategory });
        }

	   public async Task<ActionResult> Download(int? id)
	   {
		   if (id == null)
		   {
			   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		   }
		   PSS_Student_Project pSS_Student_Project = await db.PSS_Student_Project.FindAsync(id);

		   if (pSS_Student_Project == null)
		   {
			   return HttpNotFound();
		   }

		   var path = Path.Combine(Server.MapPath("~/Files"));
		   FileInfo info = new FileInfo(path+"\\"+pSS_Student_Project.file_name);
		   if (!info.Exists)
		   {
			   using (FileStream fs = info.OpenWrite())
			   {
				   fs.Write(pSS_Student_Project.document, 0, pSS_Student_Project.document.Length);
			   }
		   }

		   return File(path +"\\"+ pSS_Student_Project.file_name, "text/plain");
	   }

	    public void UploadFile(PSS_Student_Project model)
	    {
		   var path = Path.Combine(Server.MapPath("~/Files"));
		   model.documentData.SaveAs(path +"\\"+ model.file_name);
	    }

	    // GET: Professor/PSS_Student_Project/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Student_Project pSS_Student_Project = await db.PSS_Student_Project.FindAsync(id);
            if (pSS_Student_Project == null)
            {
                return HttpNotFound();
            }
            ViewBag.project_id = new SelectList(db.PSS_Projects, "project_id", "project_title", pSS_Student_Project.project_id);
            ViewBag.project_request_status_id = new SelectList(db.PSS_Status, "status_id", "status", pSS_Student_Project.project_request_status_id);
            ViewBag.student_id = new SelectList(db.PSS_Users, "user_id", "first_name", pSS_Student_Project.student_id);
            return View(pSS_Student_Project);
        }

        // POST: Professor/PSS_Student_Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "project_request_id,student_id,project_id,requested_date,project_request_status_id,document")] PSS_Student_Project pSS_Student_Project)
        {
            if (ModelState.IsValid)
            {
                pSS_Student_Project.file_name = "Test.docx";
                db.Entry(pSS_Student_Project).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.project_id = new SelectList(db.PSS_Projects, "project_id", "project_title", pSS_Student_Project.project_id);
            ViewBag.project_request_status_id = new SelectList(db.PSS_Status, "status_id", "status", pSS_Student_Project.project_request_status_id);
            ViewBag.student_id = new SelectList(db.PSS_Users, "user_id", "first_name", pSS_Student_Project.student_id);
            return View(pSS_Student_Project);
        }

        // GET: Professor/PSS_Student_Project/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Student_Project pSS_Student_Project = await db.PSS_Student_Project.FindAsync(id);
            if (pSS_Student_Project == null)
            {
                return HttpNotFound();
            }
            return View(pSS_Student_Project);
        }

        // POST: Professor/PSS_Student_Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PSS_Student_Project pSS_Student_Project = await db.PSS_Student_Project.FindAsync(id);
            db.PSS_Student_Project.Remove(pSS_Student_Project);
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
