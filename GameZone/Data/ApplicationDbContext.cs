using GameZone.Models;

namespace GameZone.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<GameDevice> GameDevices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seeding
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action" },
            new Category { Id = 2, Name = "Adventure" },
            new Category { Id = 3, Name = "RPG" },
            new Category { Id = 4, Name = "Strategy" },
            new Category { Id = 5, Name = "Sports" },
            new Category { Id = 6, Name = "Simulation" },
            new Category { Id = 7, Name = "Puzzle" },
            new Category { Id = 8, Name = "Horror" },
            new Category { Id = 9, Name = "Racing" },
            new Category { Id = 10, Name = "Multiplayer" }
        );

        modelBuilder.Entity<Device>().HasData(
            new Device { Id = 1, Name = "PC" },
            new Device { Id = 2, Name = "PlayStation" },
            new Device { Id = 3, Name = "Xbox" },
            new Device { Id = 4, Name = "Nintendo Switch" },
            new Device { Id = 5, Name = "Mobile" }
        );

        modelBuilder.Entity<GameDevice>()
            .HasKey(gd => new { gd.GameId, gd.DeviceId });

        base.OnModelCreating(modelBuilder);
    }
}
