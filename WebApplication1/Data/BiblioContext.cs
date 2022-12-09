using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class BiblioContext : DbContext
    {
        public BiblioContext (DbContextOptions<BiblioContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.User> User { get; set; } = default!;
        public DbSet<WebApplication1.Models.Auteur> Auteurs { get; set; } = default!;
        public DbSet<WebApplication1.Models.AuteurLivre> AuteurLivres { get; set; } = default!;
        public DbSet<WebApplication1.Models.Genre> Genres { get; set; } = default!;
        public DbSet<WebApplication1.Models.GenreLivre> GenresLivres { get; set; } = default!;
        public DbSet<WebApplication1.Models.Image> Images { get; set; } = default!;
        public DbSet<WebApplication1.Models.Livre> Livres { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreLivre>().HasKey(lg => new { lg.Livre_Id, lg.Genre_Id });
            modelBuilder.Entity<GenreLivre>().HasOne<Genre>(lg => lg.Genres).WithMany(lg => lg.GenreLivres).HasForeignKey(lg => lg.Genre_Id);
            modelBuilder.Entity<GenreLivre>().HasOne<Livre>(lg => lg.Livres).WithMany(lg => lg.GenreLivres).HasForeignKey(lg => lg.Livre_Id);


            modelBuilder.Entity<AuteurLivre>().HasKey(lg => new { lg.Livre_Id, lg.Auteur_Id });
            modelBuilder.Entity<AuteurLivre>().HasOne<Auteur>(la => la.Auteurs).WithMany(la => la.AuteurLivres).HasForeignKey(lg => lg.Auteur_Id);
            modelBuilder.Entity<AuteurLivre>().HasOne<Livre>(lg => lg.Livres).WithMany(lg => lg.AuteurLivres).HasForeignKey(lg => lg.Livre_Id);

        }

    }

}
