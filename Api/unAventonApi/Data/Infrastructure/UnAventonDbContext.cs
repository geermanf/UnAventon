namespace unAventonApi.Data
{
    using Microsoft.EntityFrameworkCore;

    public class UnAventonDbContext : DbContext
    {
        public UnAventonDbContext(DbContextOptions<UnAventonDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);
        // }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasAlternateKey(c => c.Email)
            .HasName("Email");
    }
    }
}