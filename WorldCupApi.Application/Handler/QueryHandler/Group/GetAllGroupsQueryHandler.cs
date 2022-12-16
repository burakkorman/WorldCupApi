using MediatR;
using WorldCupApi.Application.Services.Interfaces;
using WorldCupApi.Data.Models.QueryModels.RequestModel.Group;
using WorldCupApi.Data.Models.QueryModels.ResponseModel.Group;

namespace WorldCupApi.Application.Handler.QueryHandler.Group;

public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQuery, List<GetGroupResponse>>
{
    private readonly IGroupService _groupService;

    public GetAllGroupsQueryHandler(IGroupService groupService)
    {
        _groupService = groupService;
    }
    public async Task<List<GetGroupResponse>> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
    {
        return await _groupService.GetAll();
    }
}