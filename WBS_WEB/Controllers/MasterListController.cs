using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBS_WEB.Models;

namespace WBS_WEB.Controllers
{ 
    public class MasterListController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /MasterList/

        public ViewResult Index()
        {
            return View(db.MasterList.ToList());
        }

        //
        // GET: /MasterList/Details/5

        public ViewResult Details(int id)
        {
            MasterList masterlist = db.MasterList.Single(m => m.ID == id);
            return View(masterlist);
        }

        //
        // GET: /MasterList/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /MasterList/Create

        [HttpPost]
        public ActionResult Create(MasterList masterlist)
        {
            if (ModelState.IsValid)
            {
                db.MasterList.AddObject(masterlist);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(masterlist);
        }
        
        //
        // GET: /MasterList/Edit/5
 
        public ActionResult Edit(int id)
        {
            MasterList masterlist = db.MasterList.Single(m => m.ID == id);
            return View(masterlist);
        }

        //
        // POST: /MasterList/Edit/5

        [HttpPost]
        public ActionResult Edit(MasterList masterlist)
        {
            if (ModelState.IsValid)
            {
                db.MasterList.Attach(masterlist);
                db.ObjectStateManager.ChangeObjectState(masterlist, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masterlist);
        }

        //
        // GET: /MasterList/Delete/5
 
        public ActionResult Delete(int id)
        {
            MasterList masterlist = db.MasterList.Single(m => m.ID == id);
            return View(masterlist);
        }

        //
        // POST: /MasterList/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            MasterList masterlist = db.MasterList.Single(m => m.ID == id);
            db.MasterList.DeleteObject(masterlist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}