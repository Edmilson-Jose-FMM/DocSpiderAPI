using DocSpider.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DocSpider.Infra.Context
{
    public class SpiderDbContext : DbContext
    {
        public DbSet<Documents> Documents { get; set; }
        public SpiderDbContext(DbContextOptions<SpiderDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("documents");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(5000);

                entity.Property(e => e.Name)
                    .HasColumnName("name");
                entity.Property(e => e.Description)
                 .HasColumnName("description");

                entity.Property(e => e.Doc)
                    .HasColumnName("doc");

                entity.Property(e => e.LastEditionDate)
                    .HasColumnName("last_edition_date");

                entity.Property(e => e.Upload_Date)
                    .HasColumnName("upload_date");

                entity.Property(e => e.ContentType)
                .HasColumnName("contenttype");
            });
        }
    }
    
}
