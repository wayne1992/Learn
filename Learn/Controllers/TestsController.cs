﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Learn.Models;

namespace Learn.Controllers
{
    public class TestsController : Controller
    {
        private LearnDBEntities db = new LearnDBEntities();

        // GET: Tests
        public ActionResult Index()
        {
            var test = db.Test.Include(t => t.TestCategory);
            return View(test.ToList());
        }

        // GET: Tests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Test.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Tests/Create
        public ActionResult Create()
        {
            ViewBag.TestCategoryId = new SelectList(db.TestCategory, "TestCategoryId", "TestCategoryName");
            return View();
        }

        // POST: Tests/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestId,TestName,TestCategoryId, TestCode")] Test test)
        {
            test.TestIsDeleted = false;
            if (ModelState.IsValid)
            {
                test.TestCode = ModelState["TestCode"].Value.AttemptedValue;
                db.Test.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TestCategoryId = new SelectList(db.TestCategory, "TestCategoryId", "TestCategoryName", test.TestCategoryId);
            return View(test);
        }

        // GET: Tests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Test.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.TestCategoryId = new SelectList(db.TestCategory, "TestCategoryId", "TestCategoryName", test.TestCategoryId);
            return View(test);
        }

        // POST: Tests/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection form)
        {
            //撈取這筆資料原始値
            Test test = db.Test.Find(id);
            //驗證黑名單
            List<string> exclude = new List<string>() { "TestIsDeleted" };

            //直接修改 form["TestCode"] 値
            form["TestCode"] = "7,8,9";

            //直接修改原始資料
            test.TestCode = "2,3,4";
            //延遲驗證
            if (TryUpdateModel(test, "", null, exclude.ToArray())) {
                var modelState = ModelState;
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TestCategoryId = new SelectList(db.TestCategory, "TestCategoryId", "TestCategoryName", test.TestCategoryId);
            return View(test);
        }

        // GET: Tests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Test.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = db.Test.Find(id);
            db.Test.Remove(test);
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
