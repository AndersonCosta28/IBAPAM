using IBAPAM.ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace IBAPAM.ApiService.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        //this.Database.EnsureCreated();
        var temMigracoesPendentes = this.Database.GetPendingMigrations().Any();
        if (temMigracoesPendentes)
            this.Database.Migrate();
    }

    public DbSet<Publicacao> Publicacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Publicacao>()
            .Property(p => p.Titulo)
            .IsRequired();

        modelBuilder.Entity<Publicacao>()
            .Property(p => p.Conteudo)
            .IsRequired();
    }
}