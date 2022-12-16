using Microsoft.EntityFrameworkCore;

namespace WorldCupApi.Repository.Entities;

public class WorldCupApiDbContext : DbContext
{
    public WorldCupApiDbContext(DbContextOptions<WorldCupApiDbContext> options) : base(options)
    {
        
    }
    
    //entities
    public DbSet<Group> Groups { get; set; }
    public DbSet<Team> Teams { get; set; }
}