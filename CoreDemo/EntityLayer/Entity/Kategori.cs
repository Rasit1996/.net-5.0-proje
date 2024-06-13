using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Kategori
    {
        public Kategori()
        {
            (this).bloks=new List<Blok>();
        }
        [Key]
        public int ID { get; set; }
        public string  Adi { get; set; }
        public string  Yorum { get; set; }
        public bool  Durum { get; set; }

        public ICollection<Blok> bloks { get; set; }
    }
}
