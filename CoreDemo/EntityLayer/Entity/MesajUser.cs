using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class MesajUser
    {
        [Key]
        public int ID { get; set; }
        public int GonderenID { get; set; }
        public int AliciID { get; set; }
        public string Konu { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }

        public AppUser Gonderen { get; set; }
        public AppUser Alici  { get; set; }

        public bool  durum { get; set; }

    }
}
