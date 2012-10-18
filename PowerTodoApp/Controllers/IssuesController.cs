using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PowerTodoApp.Models;

namespace PowerTodoApp.Controllers
{   
    public class IssuesController : Controller
    {
		private readonly IIssueRepository issueRepository;
        private readonly IFriendService friendService;

		// If you are using Dependency Injection, you can delete the following constructor
        public IssuesController() : this(new IssueRepository(), new FacebookService())
        {
        }

        public IssuesController(IIssueRepository issueRepository)
        {
			this.issueRepository = issueRepository;
        }

        public IssuesController(IIssueRepository issueRepository, IFriendService friendService)
        {
            this.issueRepository = issueRepository;
            this.friendService = friendService;
        }

 
        //
        // GET: /Issues/

        public ViewResult Index()
        {
            return View(issueRepository.All.OrderBy(issue => issue.Priority));
        }

        //
        // GET: /Issues/Details/5

        public ViewResult Details(int id)
        {
            return View(issueRepository.Find(id));
        }

        //
        // GET: /Issues/Create
        [FacebookAuthorize]
        public ActionResult Create()
        {
            if (friendService != null)
                ViewBag.Friends = friendService.All.Select(friend => friend.Name);
 
            return View();
        } 

        //
        // POST: /Issues/Create

        [HttpPost]
        public ActionResult Create(Issue issue)
        {
            if (ModelState.IsValid) {
                issueRepository.InsertOrUpdate(issue);
                issueRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Issues/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(issueRepository.Find(id));
        }

        //
        // POST: /Issues/Edit/5

        [HttpPost]
        public ActionResult Edit(Issue issue)
        {
            if (ModelState.IsValid) {
                issueRepository.InsertOrUpdate(issue);
                issueRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Issues/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(issueRepository.Find(id));
        }

        //
        // POST: /Issues/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            issueRepository.Delete(id);
            issueRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                issueRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

