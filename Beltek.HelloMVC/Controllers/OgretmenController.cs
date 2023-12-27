using Beltek.HelloMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Beltek.HelloMVC.Controllers
{
    public class OgretmenController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("ListOgretmen");
        }
        public IActionResult AddOgretmen()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddOgretmen(Ogretmen ogrt)
        {
            if (!tckontrol(ogrt.Tckimlik))
            {
                ViewData["Error"] = "TCKimlik 11 haneli olmalıdır ve sadece sayısal değer içermelidir.";
                return View();
            }

            using (var ctx = new OkulDbContext())
            {
                ctx.Ogretmenler.Add(ogrt);
                ctx.SaveChanges();
            }
            return RedirectToAction("ListOgretmen");
        }

        private bool tckontrol(string tckimlik)
        {

            return !string.IsNullOrEmpty(tckimlik) && tckimlik.Length == 11 && tckimlik.All(char.IsDigit);
        }


        public IActionResult ListOgretmen()
        {
            List<Ogretmen> lst;
            using (var ctx = new OkulDbContext())
            {
                lst = ctx.Ogretmenler.ToList();
            }

            return View(lst);
        }
        public IActionResult DeleteOgretmen(string id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogrtDelet = ctx.Ogretmenler.FirstOrDefault(o => o.Tckimlik == id);

                if (ogrtDelet != null)
                {
                    ctx.Ogretmenler.Remove(ogrtDelet);
                    ctx.SaveChanges();
                    return RedirectToAction("ListOgretmen");
                }

                return NotFound("Silinecek öğretmen bulunamadı");
            }
        }


        public IActionResult UpdateOgretmen(string id)
        {
            Ogretmen ogrt;
            using (var ctx = new OkulDbContext())
            {
                ogrt =ctx.Ogretmenler.FirstOrDefault(o => o.Tckimlik == id);
            }

            if (ogrt == null)
            {
                return NotFound("Öğretmen bulunamadı");
            }

            return View(ogrt);
        }
        [HttpPost]
        public IActionResult UpdateOgretmen(Ogretmen ogrt)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Entry(ogrt).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("ListOgretmen");

        }

    }

}

