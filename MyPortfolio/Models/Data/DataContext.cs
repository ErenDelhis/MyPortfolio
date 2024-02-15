using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models.Data
{
    public class DataContext : DbContext
    {
        public DataContext():base("MyPortfolio")
        {

        }
       
        public DbSet<About> Abouts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<Servis> Serviss { get; set; }
        public DbSet<Bilgiler> Bilgi { get; set; }
        public DbSet<Ilgialani> Ilgi { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
    }
}