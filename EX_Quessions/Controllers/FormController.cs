using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EX_Quessions.Contexts;
using EX_Quessions.Models;
using Microsoft.AspNetCore.Mvc;

namespace EX_Quessions.Controllers
{
    public class FormController : Controller
    {
        readonly Context db;
        public FormController(Context db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login([Bind("FirstName,LastName")] User user)
        {
            var model = db.Users.Where(u => u.FirstName == user.FirstName && u.LastName == user.LastName);
            if (model.Count() != 0 && model.Count() != 1)
                db.Users.Add(model.First());
            TempData["fn"] = user.FirstName;
            TempData["ln"] = user.LastName;
            db.SaveChanges();
            return RedirectToAction("Insert");
        }
        public IActionResult Insert()
        {
            return View(db.Quessions.ToList());
        }
        public IActionResult CheckAnswers(string CountMaterics, string CountPlanet, string Satellite, string DayProtect, string LastName,TimeSpan TestingTime)
        {
            var rt = new ResultTesting() { CountQuessions = 5,
                EllapsedTime = DateTime.Now.TimeOfDay - TestingTime };
            var answers = new List<string>
                { CountMaterics, CountPlanet, Satellite, DayProtect, LastName };
            foreach (var answer in answers)
                if (db.Quessions.FirstOrDefault(q => q.Answer == answer) != null)
                {
                    rt.CountCorrectAnswers++;
                    rt.PercentageOfCompletion += 20;
                }
            db.ResultTestings.Add(rt);
            db.Reports.Add(new Report { FirstName = TempData["fn"].ToString(), LastName =
                TempData["ln"].ToString(), DateTesting = DateTime.Now, Result = rt.PercentageOfCompletion });
            db.SaveChanges();
            return View(rt);
        }
        public IActionResult Report() => View(db.Reports.ToArray().Reverse());
    }
}
