using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Models klasöründe oluşturduğumuz modelleri dbcontextte tanımlıyoruz.
        //veritabanına tablo eklenecekse dbset bu alanda oluşturulur.
       public DbSet<Category>Categories { get; set; }
       public DbSet<Menu>Menus { get; set; }
       public DbSet<Rezervasyon> Rezervasyons { get; set; }
       public DbSet<Galeri> Galeris { get; set; }
       public DbSet<Hakkında>Hakkındas { get; set; }
       public DbSet<Blog> Blogs { get; set; }
       public DbSet<İletisim> İletisims { get; set; }
       public DbSet<İletisimim> İletisimims { get; set; }
       public DbSet<AppUser> AppUsers { get; set; }



    }
}
