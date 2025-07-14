using DocSpider.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DocSpider.Infra.Context
{
    public class SpiderDbContext : DbContext
    {
        public SpiderDbContext(DbContextOptions<SpiderDbContext> options) : base(options) { }
        public DbSet<Documents> Documents { get; set; }
        public SpiderDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
