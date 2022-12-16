using WorldCupApi.Repository.Entities;

namespace WorldCupApi.Repository.Repositories.Interfaces;

public interface ITeamRepository : IGenericRepository<Team>
{
    Task<List<Team>> GetAllWithGroup();
    Task<Team> GetWithGroup(Guid id);
}