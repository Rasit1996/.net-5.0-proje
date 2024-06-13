using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Blok
    {
        public Blok()
        {
            (this).yorumcus=new  List<Yorumcu>();
        }
        [Key]
        public int ID { get; set; }
        public string  Baslik { get; set; }
        public string  İcerik { get; set; }
        public string  KucukGorsel { get; set; }
        public string  ImageUrl { get; set; }

        public DateTime  OlusturmaTarihi { get; set; }
        public string  Durum { get; set; }

        public int KategoriID { get; set; }
        public Kategori kategori { get; set; }

    
        public ICollection<Yorumcu> yorumcus { get; set; }

        public int UserID { get; set; }

        public AppUser User { get; set; }





    }
}
