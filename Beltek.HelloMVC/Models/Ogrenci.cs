namespace Beltek.HelloMVC.Models
{
    public class Ogrenci
    {
        public Ogrenci()
        {

        }
        public Ogrenci(int id, string ad, string soyad, string numara, string bolum)
        {
            this.Ogrenciid = id;
            this.Ad = ad;
            this.Soyad = soyad;
            this.Numara = numara;
            this.Bolum = bolum;
        }

        public Ogrenci(int id, string ad, string soyad)
        {
            this.Ogrenciid = id;
            this.Ad = ad;
            this.Soyad = soyad;           
        }

        public string Bolum { get; set; }
        public int Ogrenciid { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Numara { get; set; }

        public override string ToString()
        {
            return $"Ad:{this.Ad} Soyad:{this.Soyad} Id:{this.Ogrenciid}";
        }
    }
}
