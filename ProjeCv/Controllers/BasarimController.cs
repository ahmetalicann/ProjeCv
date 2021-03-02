using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCv.Models.Entity;
using ProjeCv.Models.Sinif;

namespace ProjeCv.Controllers
{
    public class BasarimController : Controller
    {
        // GET: Basarim
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index(string p)
        {
            //Class1 cs = new Class1();
            //cs.Deger6 = db.TBLAWARDS.ToList();
            //return View(cs);
            var degerler = from d in db.TBLAWARDS select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.AWARD.Contains(p));
            }
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult YeniHobi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniHobi(TBLAWARDS p)
        {
            db.TBLAWARDS.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult BasarimSil(int id)
        {
            var basarim = db.TBLAWARDS.Find(id);
            db.TBLAWARDS.Remove(basarim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BasarimGetir(int id)
        {
            var veri = db.TBLAWARDS.Find(id);
            return View("BasarimGetir", veri);
        }

        public ActionResult Guncelle(TBLAWARDS p)
        {
            var veriler = db.TBLAWARDS.Find(p.ID);
            veriler.ID = p.ID;
            veriler.AWARD = p.AWARD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}