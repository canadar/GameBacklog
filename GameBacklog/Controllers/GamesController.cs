using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameBacklog.Models;

namespace GameBacklog.Controllers
{
    public class GamesController : Controller
    {
        private GamesDBContext db = new GamesDBContext();

        // GET: Games
        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamesModel gamesModel = db.Games.Find(id);
            if (gamesModel == null)
            {
                return HttpNotFound();
            }
            return View(gamesModel);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameId,GameName,Platform,DateCompleted")] GamesModel gamesModel)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(gamesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gamesModel);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamesModel gamesModel = db.Games.Find(id);
            if (gamesModel == null)
            {
                return HttpNotFound();
            }
            return View(gamesModel);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameId,GameName,Platform,DateCompleted")] GamesModel gamesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gamesModel);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamesModel gamesModel = db.Games.Find(id);
            if (gamesModel == null)
            {
                return HttpNotFound();
            }
            return View(gamesModel);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GamesModel gamesModel = db.Games.Find(id);
            db.Games.Remove(gamesModel);
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
