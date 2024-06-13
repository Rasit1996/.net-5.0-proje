using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Yorumcu
    {
        [Key]
        public int ID { get; set; }
        public string  KullaniciAdi { get; set; }
        public string  Baslik { get; set; }
        public string  Icerik { get; set; }
        public DateTime YorumTarihi { get; set; }
        public double BlogPuan { get; set; }
        public bool  Durum { get; set; }
        public int BlokID { get; set; }
        public Blok blok { get; set; }


    }
}
