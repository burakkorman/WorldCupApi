using WorldCupApi.Data.Models.CommandModels.RequestModel.Team;
using WorldCupApi.Data.Models.QueryModels.ResponseModel.Team;

namespace WorldCupApi.Application.Services.Interfaces;

public interface ITeamService
{
    Task<List<GetTeamResponse>> GetAll();
    Task<GetTeamResponse> Get(Guid id);
    Task Create(CreateTeamCommand model);
    Task Update(UpdateTeamCommand model);
    Task Delete(Guid id);
}