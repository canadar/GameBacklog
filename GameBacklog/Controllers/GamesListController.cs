using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameBacklog.Models;

namespace GameBacklog.Controllers
{
    public class GamesListController : Controller
    {
        // GET: BacklogList
        public ActionResult BacklogGames()
        {
            GamesModel games = new GamesModel();
            games.Platform = "Nintendo 64";
            games.GameName = "Goldeneye 007";
            return View();
        }
    }
}