using Microsoft.EntityFrameworkCore;
using TaxiUnicoServer.Models.Classes;

namespace TaxiUnicoServer.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TarjetaCredito> TarjetasCredito { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Taxista> Taxistas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Viaje> Viajes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TarjetaCredito>()
                .HasKey(x => new { x.ClienteId, x.NumeroTarjeta });
        }
    }
}
