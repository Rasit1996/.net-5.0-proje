using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class AppUser:IdentityUser<int>
    {
        //public AppUser()
        //{
        //    (this).Bloks=new List<Blok>();
        //}
        public string SurName { get; set; }
        public string  ImageUrl { get; set; }
        public string   Hakkinda { get; set; }

        public ICollection<Blok> Bloks { get; set; }
        public ICollection<MesajUser> gonderilenler { get; set; }
        public ICollection<MesajUser> alinanlar { get; set; }

        public ICollection<Bildirim> bildirims { get; set; }



    }
}
