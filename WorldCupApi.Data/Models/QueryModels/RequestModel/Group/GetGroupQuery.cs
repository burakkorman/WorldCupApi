using MediatR;
using WorldCupApi.Data.Models.QueryModels.ResponseModel.Group;

namespace WorldCupApi.Data.Models.QueryModels.RequestModel.Group;

public class GetGroupQuery : IRequest<GetGroupResponse>
{
    public Guid Id { get; set; }
}