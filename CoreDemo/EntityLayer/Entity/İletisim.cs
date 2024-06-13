using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class İletisim
    {
        [Key]
        public int ID { get; set; }
        public  string  KullaniciAdi { get; set; }
        public string Mail  { get; set; }
        public string  Konu { get; set; }
        public  string  Mesaj { get; set; }
        public DateTime Tarih { get; set; }
        public int MyProperty { get; set; }
        public  bool  Durum { get; set; }

    }
}
