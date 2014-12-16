using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DecPlayground.Models;
using DecPlayground.DAL;
using DecPlayground.Services.Interface;
using DecPlayground.Filters;

namespace DecPlayground.Controllers
{
    [ContentHeaderActionFilter]
    public class VoteController : Controller
    {

        private IVote service;

        public VoteController(IVote service)
        {
            this.service = service;
        }

        // GET: /Vote/
        public ActionResult Result()
        {
            return View(service.GetVoteResults());
        }

        // GET: /Vote/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Email,Answer,CreatedDateTime")] VoteResult voteresult)
        {
            if (ModelState.IsValid)
            {
                if(service.IsExists(voteresult.Email))
                    ModelState.AddModelError("email","duplicate email");
                else {
                    service.AddVote(voteresult);
                    return RedirectToAction("Result");
                }
            }
            return View(voteresult);
        }

        public JsonResult PieChart()
        {
            return Json(service.GetPieChart(), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
