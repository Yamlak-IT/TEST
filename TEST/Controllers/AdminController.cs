using TEST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TEST.Controllers
{
    public class AdminController : Controller
    {
        private Context db = new Context();
        // GET: Admin
        public ActionResult Index()
        {
            var Product = db.Product;
            return View(Product.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                //Name The File By (Server Path + File Name)
                //Create Folder On The Main Project (Server) And Name It (Uploads)
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);//Saving On Server
                p.ImageURL = upload.FileName;//Save On Database                
                db.Product.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
            return View(p);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product p = db.Product.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }            
            return View(p);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Product p, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                //Contain The Old Image -If Exist-
                string OldPath = Path.Combine(Server.MapPath("~/Uploads"), p.ImageURL);

                if (upload != null)
                {
                    //Delete Old Image
                    System.IO.File.Delete(OldPath);

                    //Name The File By (Server Path + File Name)
                    //Create Folder On The Main Project (Server) And Name It (Uploads)
                    string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                    upload.SaveAs(path);//Saving On Server
                    p.ImageURL = upload.FileName;//Save On Database
                }                
                
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
            return View(p);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product p = db.Product.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Product p = db.Product.Find(id);
            db.Product.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
