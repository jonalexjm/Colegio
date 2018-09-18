using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Colegio.Backend.Models;
using Colegio.Common.Models;
using Colegio.Backend.Helpers;

namespace Colegio.Backend.Controllers
{
    public class UsersController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Users
        public async Task<ActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserView view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/User";

                if (view.PhotoFile != null)
                {
                    pic = FileHelper.UploadPhoto(view.PhotoFile, folder);
                    pic = $"{folder}/{pic}";
                }

                var user = this.ToUser(view, pic);

                db.Users.Add(user);
                await db.SaveChangesAsync();

                Helpers.Utilities.CreateUserASP(view.UserName);
                if (view.IsStudent)
                {
                    Utilities.AddRoleToUser(view.UserName, "Student");
                }
                if (view.IsTeacher)
                {
                    Utilities.AddRoleToUser(view.UserName, "Teacher");
                }


                return RedirectToAction("Index");
               
            }

            return View(view);
        }

        private Users ToUser(UserView view, string pic)
        {
            return new Users
            {
                UserName = view.UserName,
                FirstName = view.FirstName,
                LastName = view.LastName,
                Phone = view.Phone,
                Address = view.Address,
                Photo = pic,
                IsStudent = view.IsStudent,
                IsTeacher = view.IsTeacher,
            };
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return HttpNotFound();
            }

            var view = this.ToView(users);
            return View(view);
        }

        private UserView ToView(Users users)
        {
            return new UserView
            {
                
                UserName = users.UserName,
                FirstName = users.FirstName,
                LastName = users.LastName,
                Phone = users.Phone,
                Address = users.Address,
                Photo = users.Photo,
                IsStudent = users.IsStudent,
                IsTeacher = users.IsTeacher, 

                
            };
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserView view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/User";

                if (view.PhotoFile != null)
                {
                    pic = FileHelper.UploadPhoto(view.PhotoFile, folder);
                    pic = $"{folder}/{pic}";
                }

                db.Entry(view).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(view);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Users users = await db.Users.FindAsync(id);
            db.Users.Remove(users);
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
