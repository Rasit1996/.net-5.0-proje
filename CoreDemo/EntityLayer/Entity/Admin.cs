using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        public string  UserName { get; set; }
        public string Sifre { get; set; }
        public string  Name { get; set; }
        public string  Content { get; set; }
        public string  Aboout { get; set; }

        public string  ImageUrl { get; set; }
        public string  Role { get; set; }

    }
}
