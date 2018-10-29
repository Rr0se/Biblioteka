using Marta_M.Entieties;
using Marta_M.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Marta_M.Entities
{
    public class DataBaseContext : DbContext, IUnitOfWork
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<AuthorBook> AuthorBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>()
                .HasKey(u => new { u.BookId, u.AuthorId });

            modelBuilder.Entity<AuthorBook>()
               .HasOne(pe => pe.Book)
               .WithMany(p => p.AuthorBooks)
               .HasForeignKey(pc => pc.BookId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AuthorBook>()
                .HasOne(pe => pe.Author)
                .WithMany(p => p.AuthorBooks)
                .HasForeignKey(pc => pc.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            //---------------------------------------------
            modelBuilder.Entity<GenreBook>()
                .HasKey(u => new { u.BookId, u.GenreId });

            modelBuilder.Entity<GenreBook>()
               .HasOne(pe => pe.Book)
               .WithMany(p => p.GenreBooks)
               .HasForeignKey(pc => pc.BookId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GenreBook>()
                .HasOne(pe => pe.Genre)
                .WithMany(p => p.GenreBooks)
                .HasForeignKey(pc => pc.GenreId)
                .OnDelete(DeleteBehavior.Cascade);



        }

    }
}
