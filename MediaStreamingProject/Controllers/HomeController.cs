using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaStreamingProject.Models;

namespace MediaStreamingProject.Controllers {
    public class HomeController : Controller {

        private TvShowDBEntities db = new TvShowDBEntities();

        public ActionResult Index() {
            var tvShows = db.TvShows.Include(t => t.Network);
            return View(tvShows.ToList());
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}