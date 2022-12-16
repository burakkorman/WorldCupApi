using MediatR;
using WorldCupApi.Data.Models.QueryModels.ResponseModel.Group;

namespace WorldCupApi.Data.Models.QueryModels.RequestModel.Group;

public class GetAllGroupsQuery : IRequest<List<GetGroupResponse>>
{
    
}