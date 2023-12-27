using Beltek.HelloMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beltek.HelloMVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("ListStudent");
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Ogrenci ogr)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Ogrenciler.Add(ogr);
                ctx.SaveChanges();
            }
            return RedirectToAction("ListStudent");
        }

        public IActionResult ListStudent()
        {
            List<Ogrenci> lst;
            using (var ctx = new OkulDbContext())
            {
                lst = ctx.Ogrenciler.ToList();
            }

            return View(lst);
        }

        public IActionResult DeleteStudent(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogr = ctx.Ogrenciler.Find(id);
                ctx.Ogrenciler.Remove(ogr);
                ctx.SaveChanges();
            }
            return RedirectToAction("ListStudent");
        }


        public IActionResult UpdateStudent(int id)
        {
            Ogrenci ogr;
            using (var ctx = new OkulDbContext())
            {
                ogr = ctx.Ogrenciler.Find(id);
            }
            return View(ogr);
        }

        [HttpPost]
        public IActionResult UpdateStudent(Ogrenci ogr)
        {
            using (var ctx=new OkulDbContext())
            {
                ctx.Entry(ogr).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("ListStudent");
        }

    }
}
