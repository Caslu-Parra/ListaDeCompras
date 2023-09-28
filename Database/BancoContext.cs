using ListaDeCompras.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeCompras.Database
{
    public class BancoContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoModel>().HasKey("Id", "ProdutoId" );

        }

        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        public DbSet<UsuarioModel>? Usuarios { get; set; }
        public DbSet<PedidoModel>? Compras { get; set; }
        public DbSet<ProdutoModel>? Produtos { get; set; }
        public DbSet<PedidoModel>? Pedidos { get; set; }

    }
}