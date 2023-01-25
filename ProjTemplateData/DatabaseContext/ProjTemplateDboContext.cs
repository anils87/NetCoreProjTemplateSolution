using Microsoft.EntityFrameworkCore;
using ProjTemplateData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateData
{
    public class ProjTemplateDboContext : DbContext
    {
        public ProjTemplateDboContext() { }
        public ProjTemplateDboContext(DbContextOptions<ProjTemplateDboContext> options) : base(options) 
        { 

        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(a => a.Id);
            modelBuilder.Entity<Category>().HasKey(a => a.Id);

        }
    }
}
