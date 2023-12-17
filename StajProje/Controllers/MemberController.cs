using StajProje.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StajProje.Controllers
{
    public class MemberController : Controller
    {
        Model1 db = new Model1();

        public ActionResult Index()
        {
            var memberList = db.Members.ToList();
            return View(memberList);
        }


        [HttpGet]
        public ActionResult Insert()
        {
            Members member = new Members();
            return View(member);
        }

        [HttpPost]
        public ActionResult Insert(Members member)
        {
            db.Members.Add(member);
            db.SaveChanges();
            return RedirectToAction("Index"); ;
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var member = db.Members.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(member);
        }
        [HttpPost]
        public ActionResult Edit(Members member)
        {
            if (ModelState.IsValid)
            {
                //Bunu da yapabilirsin ama bir alttaki satırla yaz :)
               // db.Entry(member).State = EntityState.Modified;
                db.Members.AddOrUpdate(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public ActionResult Delete(int id)
        {
            var member = db.Members.Find(id);
            if (member != null)
            {
                db.Members.Remove(member);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Statistics()
        {
            var members = db.Members.ToList();

            if (!members.Any())
            {
                return View("NoMembers");  
            }

            var maleCount = members.Count(m => m.gender.StartsWith("M"));
            var femaleCount = members.Count(m => m.gender.StartsWith("F"));

        
            double averageAge = members.Average(m => int.TryParse(m.age, out var ageValue) ? ageValue : 0);

            var stats = new StatisticsModel
            {
                TotalMembers = members.Count,
                MaleMembers = maleCount,
                FemaleMembers = femaleCount,
                AverageAge = averageAge
            };

            return View(stats);
        }


    }
}