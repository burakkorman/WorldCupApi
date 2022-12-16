using Microsoft.EntityFrameworkCore;
using WorldCupApi.Repository.Entities;
using WorldCupApi.Repository.Repositories.Interfaces;

namespace WorldCupApi.Repository.Repositories;

public class TeamRepository : GenericRepository<Team>, ITeamRepository
{
    public TeamRepository(WorldCupApiDbContext context) : base(context)
    {
    }

    public async Task<List<Team>> GetAllWithGroup()
    {
        return await _entities
            .AsNoTracking()
            .Include(x => x.Group)
            .Where(x => x.IsActive)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Team> GetWithGroup(Guid id)
    {
        return await _entities
            .AsNoTracking()
            .Include(x => x.Group)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}