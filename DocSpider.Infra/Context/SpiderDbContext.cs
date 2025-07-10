using DocSpider.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DocSpider.Infra.Context
{
    public class SpiderDbContext : DbContext
    {
        public SpiderDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Documents> movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
