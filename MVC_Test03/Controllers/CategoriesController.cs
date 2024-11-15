﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Test03.Models;

namespace MVC_Test03.Controllers
{
    
    
    public class CategoriesController : Controller
    {
        
        private DBSportStoreEntities db = new DBSportStoreEntities();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            ViewBag.Role = Session["UserRole"]; // Lấy vai trò từ session và gán cho ViewBag
        }
        // GET: Categories
        public ActionResult Index()
        {
            if (ViewBag.Role != "Admin")
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(db.Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(string id)
        {

            if (ViewBag.Role != "Admin")
            {
                return RedirectToAction("NotFound", "Error");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            if (ViewBag.Role != "Admin")
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IDCate,NameCate")] Category category)
        {
            if (ViewBag.Role != "Admin")
            {
                return RedirectToAction("NotFound", "Error");
            }

            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(string id)
        {
            if (ViewBag.Role != "Admin")
            {
                return RedirectToAction("NotFound", "Error");
            }

            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IDCate,NameCate")] Category category)
        {

            if (ViewBag.Role != "Admin")
            {
                return RedirectToAction("NotFound", "Error");
            }
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(string id)
        {

            if (ViewBag.Role != "Admin")
            {
                return RedirectToAction("NotFound", "Error");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            if (ViewBag.Role != "Admin")
            {
                return RedirectToAction("NotFound", "Error");
            }

            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
