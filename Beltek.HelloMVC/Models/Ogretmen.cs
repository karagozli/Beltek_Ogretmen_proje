using System.ComponentModel.DataAnnotations;

namespace Beltek.HelloMVC.Models
{
    public class Ogretmen
    {
        [Key]
        public string Tckimlik { get; set; }//Id Primary Key- Fluent Api 
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Alan { get; set; }
    }
}
