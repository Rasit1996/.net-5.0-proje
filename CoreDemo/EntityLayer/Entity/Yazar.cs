using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Yazar
    {
        public Yazar()
        {
           
            (this).bildirims=new   List<Bildirim>();
            (this).Gonderilenler = new List<Mesaj2>();
            (this).Alinanlar = new List<Mesaj2>();
        }
        [Key]
        public int ID { get; set; }
        public string  Adi { get; set; }
        public string  Soyadi { get; set; }
        public string  Hakkinda { get; set; }
        public string  ImageUrl { get; set; }
        public string   Mail { get; set; }
        public  string  Sifre { get; set; }

        public bool  Durum { get; set; }
   

        public ICollection<Bildirim> bildirims { get; set; }
        public ICollection<Mesaj2> Gonderilenler { get; set; }
        public ICollection<Mesaj2> Alinanlar { get; set; }






    }
}
