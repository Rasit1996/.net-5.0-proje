using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Hakkinda
    {
        [Key]
        public  int  ID { get; set; }
        public string  Detaylar1 { get; set; }
        public string  Detaylar2 { get; set; }
        public string  Image1 { get; set; }
        public string  Image2 { get; set; }
        public string  MapLocation { get; set; }
        public bool  Durum { get; set; }

    }
}
