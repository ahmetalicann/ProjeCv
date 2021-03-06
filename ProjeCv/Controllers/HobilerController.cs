﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCv.Models.Entity;
using ProjeCv.Models.Sinif;

namespace ProjeCv.Controllers
{
    public class HobilerController : Controller
    {
        // GET: Hobiler
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger5 = db.TBLINTERESTS.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult YeniHobi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniHobi(TBLINTERESTS p)
        {
            db.TBLINTERESTS.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult HobiSil(int id)
        {
            var hobi = db.TBLINTERESTS.Find(id);
            db.TBLINTERESTS.Remove(hobi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult HobiGetir(int id)
        {
            var veri = db.TBLINTERESTS.Find(id);
            return View("HobiGetir", veri);
        }

        public ActionResult Guncelle(TBLINTERESTS p)
        {
            var veriler = db.TBLINTERESTS.Find(p.ID);
            veriler.ID = p.ID;
            veriler.INTEREST = p.INTEREST;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}