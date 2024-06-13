using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Mesaj
    {
        [Key]
        public int ID { get; set; }
        public string Gonderen { get; set; }
        public string  Alici { get; set; }
        public string  Konu { get; set; }
        public string  Icerik { get; set; }
        public DateTime Tarih { get; set; }
       
        public bool Durum { get; set; }


    }
}
