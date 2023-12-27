using Beltek.HelloMVC.Models;
using Beltek.HelloMVC.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Beltek.HelloMVC.Controllers
{
    public class OgrenciController : Controller
    {//URL Routing
        public ViewResult Index()//Action Metod
        {
            return View();
        }

        public ViewResult OgrenciEkle()
        {
            return View("AddStudent");
        }

        public ViewResult OgrenciDetay(int id)
        {
            Ogrenci ogrenci = null;
            Ogretmen ogretmen = null;

            if (id == 1)
            {
                ogrenci = new Ogrenci(1, "Ali", "Veli");
                //ogretmen = new Ogretmen { Id = 1, Ad = "Osman", Soyad = "Yıldız", Alan = "Matematik" };
            }
            else if (id == 2)
            {
                ogrenci = new Ogrenci(2, "Ahmet", "Mehmet");
                //ogretmen = new Ogretmen { Id = 2, Ad = "Veysel", Soyad = "Yılmaz", Alan = "Türkçe" };
            }

            ViewData["ogr"] = ogrenci;

            ViewBag.student = ogrenci;

            var dto = new OgrenciDTO();
            dto.Teacher = ogretmen;
            dto.Student = ogrenci;

            return View(dto);
        }

        public ViewResult OgrenciListe()
        {
            var ogr = new Ogrenci(1, "Ahmet", "Soyad");
            var ogr1 = new Ogrenci(2, "Ali", "Veli");

            Ogrenci[] ogrenciler = new Ogrenci[2];
            ogrenciler[0] = ogr;
            ogrenciler[1] = ogr1;

            ViewData["students"] = ogrenciler;
            ViewBag.ogrenciler = ogrenciler;

            return View(ogrenciler);
        }

        public ViewResult StudentList()
        {
            var ogr = new Ogrenci(1, "Ahmet", "Soyad");
            var ogr1 = new Ogrenci(2, "Ali", "Veli");

            var lst = new List<Ogrenci> { ogr, ogr1 };
            return View(lst);
        }
    }
}

//Controller'dan View'e Veri Taşıma
//ViewData: Key-Value çiftlerinden oluşan bir koleksiyondur. Keylerin veri tipleri string, value'ların veri tipleri object'dir.
//ViewBag: ViewData ile aynı key-value koleksiyonunu kullanır. Bu nedenle key'ler verilirken dikkat edilmelidir.
//ViewModel: Controller'dan View'e View() metodu aracılığı ile veri taşıma. View() metoduna gönderilen veri, View tarafında @model ifadesi ile karşılandıktan sonra, View içerisinde istenilen yerde @Model ifadesi ile ulaşılarak kullanılabilir. Bu yöntemde taşınan veriler de object tipindedir. 

//DTO: Data Transfer Object: Birden fazla veri tipinde olan değerleri modellemek amacıyla kullanılan classlardır.
