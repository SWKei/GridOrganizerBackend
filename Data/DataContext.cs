namespace GridOrganizerBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Grid> Grids { get; set; }
        public DbSet<GridItem> GridItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grid>()
                .HasMany(e => e.GridItems)
                .WithOne()
                .HasForeignKey("GridId");
        }
    }
}