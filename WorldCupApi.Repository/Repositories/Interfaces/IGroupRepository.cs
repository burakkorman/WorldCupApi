using WorldCupApi.Repository.Entities;

namespace WorldCupApi.Repository.Repositories.Interfaces;

public interface IGroupRepository : IGenericRepository<Group>
{
    Task<int> GetTotalGroupCount();
    Task<int> GetTeamCountById(Guid id);
}