using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using Shop.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Shop.Persistence.Contexto
{
    public class ShopContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
                                                        UserRole, IdentityUserLogin<int>,
                                                        IdentityRoleClaim<int>, IdentityUserToken<int>>
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

            modelBuilder.Entity<UserRole>(userRole => {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

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
