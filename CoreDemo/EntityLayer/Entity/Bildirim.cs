using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Bildirim
    {
        [Key]
        public int ID { get; set; }
        public string  ClassTip { get; set; }
        public string Konu { get; set; }
        public string  Icerik { get; set; }
        public int YazarID { get; set; }
        public Yazar yazar { get; set; }
        public bool Durum { get; set; }

        public AppUser user { get; set; }
        public int userID { get; set; }



    }
}
