using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PowerTodoApp.Models;

namespace PowerTodoApp.Controllers
{   
    public class IssuesController : Controller
    {
        private PowerTodoAppContext context = new PowerTodoAppContext();

        //
        // GET: /Issues/

        public ViewResult Index()
        {
            return View(context.Issues.ToList());
        }

        //
        // GET: /Issues/Details/5

        public ViewResult Details(int id)
        {
            Issue issue = context.Issues.Single(x => x.Key == id);
            return View(issue);
        }

        //
        // GET: /Issues/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Issues/Create

        [HttpPost]
        public ActionResult Create(Issue issue)
        {
            if (ModelState.IsValid)
            {
                context.Issues.Add(issue);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(issue);
        }
        
        //
        // GET: /Issues/Edit/5
 
        public ActionResult Edit(int id)
        {
            Issue issue = context.Issues.Single(x => x.Key == id);
            return View(issue);
        }

        //
        // POST: /Issues/Edit/5

        [HttpPost]
        public ActionResult Edit(Issue issue)
        {
            if (ModelState.IsValid)
            {
                context.Entry(issue).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(issue);
        }

        //
        // GET: /Issues/Delete/5
 
        public ActionResult Delete(int id)
        {
            Issue issue = context.Issues.Single(x => x.Key == id);
            return View(issue);
        }

        //
        // POST: /Issues/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Issue issue = context.Issues.Single(x => x.Key == id);
            context.Issues.Remove(issue);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}