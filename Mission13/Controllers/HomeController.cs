//Home Controller

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {

        private IBowlingRepository _repo { get; set; }

        //Constructor
        public HomeController(IBowlingRepository temp)
        {
            _repo = temp;
        }

        //Bowler Contact List View (Home Page)
        public IActionResult Index(string teamName)
        {
            ViewBag.TeamName = teamName;

            var bowlersList = _repo.Bowlers.Include(x => x.Team)
                .Where(b => b.Team.TeamName == teamName || teamName == null)
                .ToList();


            return View(bowlersList);
   
        }

        //Add Bowler View
        [HttpGet]
        public IActionResult BowlerForm()
        {
            ViewBag.Teams = _repo.Teams.ToList();

            return View(new Bowler());
        }

        [HttpPost]
        public IActionResult BowlerForm(Bowler bowlerInstance)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateBowler(bowlerInstance);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Teams = _repo.Teams.ToList();
                
                return View(bowlerInstance);
            }
        }


        //Edit Bowler
        [HttpGet]
        public IActionResult EditBowler(int bowlerid)
        {
            ViewBag.Teams = _repo.Teams.ToList();

            var getBowlerEdit = _repo.Bowlers.Single(y => y.BowlerID == bowlerid);

            return View("BowlerForm", getBowlerEdit);
        }

        [HttpPost]
        public IActionResult EditBowler(Bowler bowlerInstance)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateBowler(bowlerInstance);

                return RedirectToAction("Index");
            }
            else // if invalid
            {
                ViewBag.Teams = _repo.Teams.ToList();
                
                return View("BowlerForm", bowlerInstance);
            }
        }


        //Delete Bowler
        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var getBowlerDelete = _repo.Bowlers.Single(y => y.BowlerID == bowlerid);

            return View(getBowlerDelete);
        }

        [HttpPost]
        public IActionResult Delete(Bowler bowlerInstance)
        {
            _repo.DeleteBowler(bowlerInstance);

            return RedirectToAction("Index");
        }

    }
}
