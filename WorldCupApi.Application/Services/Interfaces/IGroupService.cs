using WorldCupApi.Data.Models.CommandModels.RequestModel.Group;
using WorldCupApi.Data.Models.QueryModels.ResponseModel.Group;
using WorldCupApi.Repository.Entities;

namespace WorldCupApi.Application.Services.Interfaces;

public interface IGroupService
{
    Task<List<GetGroupResponse>> GetAll();
    Task<GetGroupResponse> Get(Guid id);
    Task Create(CreateGroupCommand model);
    Task Update(UpdateGroupCommand model);
    Task Delete(Guid id);
}