using Microsoft.EntityFrameworkCore;
using WorldCupApi.Repository.Entities;
using WorldCupApi.Repository.Repositories.Interfaces;

namespace WorldCupApi.Repository.Repositories;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(WorldCupApiDbContext context) : base(context)
    {
    }

    public async Task<int> GetTotalGroupCount()
    {
        return await _entities.Where(x => x.IsActive).CountAsync();
    }

    public async Task<int> GetTeamCountById(Guid id)
    {
        var group = await _entities
                .Include(x => x.Teams.Where(t => t.IsActive))
                .FirstOrDefaultAsync(x => x.Id == id);

        if (group is null)
            throw new Exception("Grup bulunamadı.");

        return group.Teams.Count();
    }
}