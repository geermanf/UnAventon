namespace unAventonApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using unAventonApi.Data.Entities;
    using unAventonApi.Data.Entities.TablasIntermedias;

    public class UnAventonDbContext : DbContext
    {
        public UnAventonDbContext(DbContextOptions<UnAventonDbContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Viaje> Viaje { get; set; }
        public DbSet<DiaDeViaje> DiaDeViaje { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<TipoTarjeta> TipoTarjeta { get; set; }

        public DbSet<Banco> Banco { get; set; }

        public DbSet<Calificacion> Calificacion { get; set; }
        public DbSet<Rol> Rol { get; set; }

        public DbSet<TipoCalificacion> TipoCalificacion { get; set; }

        public DbSet<Postulantes> Postulantes { get; set; }

        public DbSet<Viajeros> Viajeros { get; set; }

        public DbSet<ViajesPendientes> ViajesPendientes { get; set; }

        public DbSet<ViajesRealizados> ViajesRealizados { get; set; }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);
        // }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasAlternateKey(c => c.Email)
                .HasName("Email");
            modelBuilder.Entity<Postulantes>()
                .HasKey(t => new { t.UserId, t.ViajeId });
            modelBuilder.Entity<Postulantes>()
                .HasOne(v => v.Viaje)
                .WithMany(p => p.Postulantes)
                .HasForeignKey(v => v.ViajeId);

            modelBuilder.Entity<Viajeros>()
                .HasKey(t => new { t.UserId, t.ViajeId });
            modelBuilder.Entity<Viajeros>()
                .HasOne(v => v.Viaje)
                .WithMany(p => p.Viajeros)
                .HasForeignKey(v => v.ViajeId);

            modelBuilder.Entity<ViajesPendientes>()
                .HasKey(t => new { t.UserId, t.ViajeId });
            modelBuilder.Entity<ViajesPendientes>()
                .HasOne(u => u.User)
                .WithMany(vp => vp.ViajesPendientes)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<ViajesRealizados>()
                .HasKey(t => new { t.UserId, t.ViajeId });
            modelBuilder.Entity<ViajesRealizados>()
                .HasOne(u => u.User)
                .WithMany(vr => vr.ViajesRealizados)
                .HasForeignKey(u => u.UserId);
            
            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.UsuarioPuntuador)
                .WithMany(e => e.CalificacionesBrindadas)
                .IsRequired();

            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.UsuarioCalificado)
                .WithMany(e => e.CalificacionesRecibidas)
                .IsRequired();

            modelBuilder.Entity<Pregunta>()
                .HasOne(c => c.Viaje)
                .WithMany(e => e.Preguntas);
        }
    }
}