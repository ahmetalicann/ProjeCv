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
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger6 = db.TBLAWARDS.ToList();
            return View(cs);
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
    }
}