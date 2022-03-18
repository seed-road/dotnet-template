using Microsoft.EntityFrameworkCore;
using SeedRoad.Template.Infrastructure.Database.Models;

namespace SeedRoad.Template.Infrastructure.Database.Contexts;

public class TemplateContext : DbContext
{
    public DbSet<TemplateModel> Templates { get; set; }

    public TemplateContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TemplateModel>(builder =>
        {
            builder.ToTable("template")
                .Property(p => p.Id)
                .ValueGeneratedNever();
        });;
    }
}