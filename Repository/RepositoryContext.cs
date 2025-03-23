using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configurations;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new FrameConfiguration());
    }

    public DbSet<Player>? Players { get; set; }
    public DbSet<Game>? Games { get; set; }
    public DbSet<Frame>? Frames { get; set; }
    public DbSet<GameFrame>? GameFrames { get; set; }

}