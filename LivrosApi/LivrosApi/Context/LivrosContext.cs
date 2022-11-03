using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Context
{
    public class LivrosContext : DbContext
    {
        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options)
        {
        }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Editora> Editoras { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Editora>().HasKey(e => e.EditoraId);

            mb.Entity<Editora>().Property(e => e.CNPJ)
                                  .HasMaxLength(20)
                                  .IsRequired();

            mb.Entity<Editora>().Property(e => e.RazaoSocial)
                                  .HasMaxLength(100)
                                  .IsRequired();

            mb.Entity<Editora>().Property(e => e.NomeFantasia)
                                  .HasMaxLength(100)
                                  .IsRequired();

            mb.Entity<Livro>().HasKey(l => l.LivrosId);

            mb.Entity<Livro>().Property(l => l.Titulo)
                                  .HasMaxLength(100)
                                  .IsRequired();

            mb.Entity<Livro>().Property(l => l.Preco)
                                  .HasPrecision(14, 2)
                                  .IsRequired();

            mb.Entity<Livro>().Property(l => l.ISBN)
                                  .HasMaxLength(20)
                                  .IsRequired();

            mb.Entity<Livro>()
                .HasOne<Editora>(e => e.Editora)
                    .WithMany(l => l.Livros)
                        .HasForeignKey(e => e.EditoraId);
        }
    }
}
