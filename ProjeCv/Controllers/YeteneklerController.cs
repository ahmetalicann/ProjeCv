using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCv.Models.Entity;
using ProjeCv.Models.Sinif;
using PagedList;
using PagedList.Mvc;

namespace ProjeCv.Controllers
{
    public class YeteneklerController : Controller
    {
        // GET: Yetenekler
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index(int sayfa=1)
        {
            
            var degerler = db.TBLSKILLS.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBLSKILLS p) 
        {
            db.TBLSKILLS.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = db.TBLSKILLS.Find(id);
            db.TBLSKILLS.Remove(yetenek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YetenekGetir(int id)
        {
            var veri = db.TBLSKILLS.Find(id);
            return View("YetenekGetir", veri);
        }

        public ActionResult Guncelle(TBLSKILLS p)
        {
            var veriler = db.TBLSKILLS.Find(p.ID);
            veriler.ID = p.ID;
            veriler.SKILL = p.SKILL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}