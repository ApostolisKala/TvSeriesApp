using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TvSeriesApp.Models;

namespace TvSeriesApp.Controllers
{
    public class SeriesController : Controller
    {
        private SerieDbContext db = new SerieDbContext();

        // GET: Series
        public ActionResult Index(string searchString, string serieGenre, int? seasons)
        {

            // ------------------------------ Search title -------------------------------------
            var series = from b in db.Series   // rwtaei ti vasi
                         select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                series = series.Where(s => s.Title.Contains(searchString));   // kanei linQ panw sthn lista books kai emfanizei ta apotelesmata
            }

            // ------------------------------ Search Number of seasons -------------------------------------
            var seasonList = new List<int>();

            var seasonQuery = from s in series
                              orderby s.NumberOfSeasons
                              select s.NumberOfSeasons;      // kanw linq panw sta dedomena pou efere h series

            seasonList.AddRange(seasonQuery.Distinct());
            ViewBag.Seasons = new SelectList(seasonList);

            if (seasons != null)
            {
                series = series.Where(mi => mi.NumberOfSeasons == seasons);
            }

            // ------------------------------ Search with Genre -------------------------------------
            var GenreList = new List<string>();

            var GenreQuery = from l in series
                             orderby l.Genre
                             select l.Genre;   // kanw linq panw stin series pou periexei ola ta stoixeia ths vasis

            GenreList.AddRange(GenreQuery.Distinct());
            ViewBag.SerieGenre = new SelectList(GenreList);

            if (!String.IsNullOrEmpty(serieGenre))
            {
                series = series.Where(m => m.Genre == serieGenre);
            }

            return View(series);
        }

        // GET: Series/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serie serie = db.Series.Find(id);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        // GET: Series/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SerieID,Title,ReleasedDate,NumberOfSeasons,Genre,Rating")] Serie serie)
        {
            if (ModelState.IsValid)
            {
                db.Series.Add(serie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serie);
        }

        // GET: Series/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serie serie = db.Series.Find(id);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        // POST: Series/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SerieID,Title,ReleasedDate,NumberOfSeasons,Genre,Rating")] Serie serie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serie);
        }

        // GET: Series/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serie serie = db.Series.Find(id);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Serie serie = db.Series.Find(id);
            db.Series.Remove(serie);
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
