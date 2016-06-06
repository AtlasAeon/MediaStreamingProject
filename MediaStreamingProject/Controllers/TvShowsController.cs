using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MediaStreamingProject.Models;

namespace MediaStreamingProject.Controllers
{
    public class TvShowsController : Controller
    {
        private TvShowDBEntities db = new TvShowDBEntities();

        // GET: TvShows
        public ActionResult Index()
        {
            var tvShows = db.TvShows.Include(t => t.Network);
            return View(tvShows.ToList());
        }

        // GET: TvShows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TvShow tvShow = db.TvShows.Find(id);
            if (tvShow == null)
            {
                return HttpNotFound();
            }
            return View(tvShow);
        }

        // GET: TvShows/Create
        public ActionResult Create()
        {
            ViewBag.NetworkID = new SelectList(db.Networks, "NetworkID", "NetName");
            return View();
        }

        // POST: TvShows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowID,NetworkID,ShowName,Seasons,StartYear,ImdbRating,TvShow_Image_Link")] TvShow tvShow)
        {
            if (ModelState.IsValid)
            {
                db.TvShows.Add(tvShow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NetworkID = new SelectList(db.Networks, "NetworkID", "NetName", tvShow.NetworkID);
            return View(tvShow);
        }

        // GET: TvShows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TvShow tvShow = db.TvShows.Find(id);
            if (tvShow == null)
            {
                return HttpNotFound();
            }
            ViewBag.NetworkID = new SelectList(db.Networks, "NetworkID", "NetName", tvShow.NetworkID);
            return View(tvShow);
        }

        // POST: TvShows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowID,NetworkID,ShowName,Seasons,StartYear,ImdbRating,TvShow_Image_Link")] TvShow tvShow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tvShow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NetworkID = new SelectList(db.Networks, "NetworkID", "NetName", tvShow.NetworkID);
            return View(tvShow);
        }

        // GET: TvShows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TvShow tvShow = db.TvShows.Find(id);
            if (tvShow == null)
            {
                return HttpNotFound();
            }
            return View(tvShow);
        }

        // POST: TvShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TvShow tvShow = db.TvShows.Find(id);
            db.TvShows.Remove(tvShow);
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
