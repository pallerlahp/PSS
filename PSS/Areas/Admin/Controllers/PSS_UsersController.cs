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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

using System.Globalization;

using System.Security.Claims;



namespace PSS.Areas.Admin.Controllers
{
    public class PSS_UsersController : Controller
    {
        private PSSEntities db = new PSSEntities();

        // GET: Admin/PSS_Users
        public async Task<ActionResult> Index()
        {
            var pSS_Users = db.PSS_Users.Include(p => p.PSS_User_Type);
            return View(await pSS_Users.ToListAsync());
        }

        // GET: Admin/PSS_Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Users pSS_Users = await db.PSS_Users.FindAsync(id);
            if (pSS_Users == null)
            {
                return HttpNotFound();
            }
            return View(pSS_Users);
        }

        // GET: Admin/PSS_Users/Create
        public ActionResult Create()
        {
            ViewBag.user_type_id = new SelectList(db.PSS_User_Type, "user_type_id", "type");

            return View();
        }

        // POST: Admin/PSS_Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "user_id,first_name,last_name,email,contact,user_type_id,active")] PSS_Users pSS_Users)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = pSS_Users.email, Email = pSS_Users.email };
                var result = await UserManager.CreateAsync(user, "");
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                
                pSS_Users.active = true;
                db.PSS_Users.Add(pSS_Users);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.user_type_id = new SelectList(db.PSS_User_Type, "user_type_id", "type", pSS_Users.user_type_id);
            return View(pSS_Users);
        }

        // GET: Admin/PSS_Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Users pSS_Users = await db.PSS_Users.FindAsync(id);
            if (pSS_Users == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_type_id = new SelectList(db.PSS_User_Type, "user_type_id", "type", pSS_Users.user_type_id);
            return View(pSS_Users);
        }

        // POST: Admin/PSS_Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "user_id,first_name,last_name,email,contact,user_type_id,active")] PSS_Users pSS_Users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pSS_Users).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.user_type_id = new SelectList(db.PSS_User_Type, "user_type_id", "type", pSS_Users.user_type_id);
            return View(pSS_Users);
        }

        // GET: Admin/PSS_Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSS_Users pSS_Users = await db.PSS_Users.FindAsync(id);
            if (pSS_Users == null)
            {
                return HttpNotFound();
            }
            return View(pSS_Users);
        }

        // POST: Admin/PSS_Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PSS_Users pSS_Users = await db.PSS_Users.FindAsync(id);
            db.PSS_Users.Remove(pSS_Users);
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
