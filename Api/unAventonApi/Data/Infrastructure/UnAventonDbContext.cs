namespace unAventonApi.Data
{
    using Microsoft.EntityFrameworkCore;

    public class UnAventonDbContext : DbContext
    {
        public UnAventonDbContext(DbContextOptions<UnAventonDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}