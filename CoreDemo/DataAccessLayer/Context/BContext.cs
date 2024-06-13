using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class BContext:IdentityDbContext<AppUser,AppRoles,int>  
        {
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-LAHHDS9;database=CoreDemoBlock;integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<KategoriPuan>().HasNoKey();
            modelBuilder.Entity<BlogPuan>().HasNoKey();

            modelBuilder.Entity<Mesaj2>()
                .HasOne(x => x.Alici).WithMany(x => x.Alinanlar).HasForeignKey(x => x.AliciID).OnDelete(DeleteBehavior.Restrict).IsRequired();
            modelBuilder.Entity<Mesaj2>()
                .HasOne(x => x.Gonderen).WithMany(x => x.Gonderilenler).HasForeignKey(x => x.GonderenID).OnDelete(DeleteBehavior.Restrict).IsRequired();
            
            modelBuilder.Entity<MesajUser>().HasOne(x => x.Gonderen).WithMany(x => x.gonderilenler).HasForeignKey(x => x.GonderenID)
                .OnDelete(DeleteBehavior.Restrict).IsRequired();
            modelBuilder.Entity<MesajUser>().HasOne(x => x.Alici).WithMany(x => x.alinanlar).HasForeignKey(x => x.AliciID)
                .OnDelete(DeleteBehavior.Restrict).IsRequired();
            
            //modelBuilder.Entity<Blok>().HasOne(x => x.User).WithMany(x => x.bloks).HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Restrict).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        

        public DbSet<Kategori> kategoris { get; set; }
        public DbSet<İletisim> iletisims { get; set; }
        public DbSet<Blok> bloks { get; set; }
        public DbSet<Hakkinda> hakkindas { get; set; }
        public DbSet<Yazar> yazars { get; set; }
        public DbSet<Yorumcu> yorumcus { get; set; }

        public DbSet<HaberBulteni> haberBultenis { get; set; }
     
        public DbSet<KategoriPuan> kategoriPuans { get; set; }

        public DbSet<BlogPuan> blogPuans { get; set; }

        public DbSet<Bildirim> bildirims { get; set; }
        public DbSet<Mesaj> mesajs { get; set; }

        public DbSet<Mesaj2> mesaj2s { get; set; }

        public DbSet<Admin> admins { get; set; }

        public DbSet<MesajUser> mesajUsers { get; set; }


    }
}
