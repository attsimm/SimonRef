using DcComics.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DcComics.DAL
{
    public class DCcontext : DbContext
    {
        public DCcontext()
            : base("DCcontext")
        {
            
        }
        public DbSet<Comics> Comics { get; set; }
        public DbSet<Superheroes> Heroes { get; set; }
        public DbSet<Villains> Villains { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}