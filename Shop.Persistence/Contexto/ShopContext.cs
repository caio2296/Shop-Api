using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Contexto
{
    public class ShopContext : DbContext
    {

        public ShopContext(DbContextOptions<ShopContext> options) : base(options) {

            //base.Database.EnsureCreated();
        }



        public DbSet<Produto> produtos { get; set; }

        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Fornecedor> fornecedores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>();
            modelBuilder.Entity<Produto>()
                .HasOne(f => f.Fornecedor)
                .WithMany(p => p.Produtos)
                .HasForeignKey(f => f.Fornecedor_id);

            modelBuilder.Entity<Produto>()
                .HasOne(c => c.Categoria)
                .WithMany(p => p.Produtos)
                .HasForeignKey(c => c.Categoria_id);

        }
    }
}
