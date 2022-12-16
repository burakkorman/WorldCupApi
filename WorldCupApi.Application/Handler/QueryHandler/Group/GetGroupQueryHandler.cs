using MediatR;
using WorldCupApi.Application.Services.Interfaces;
using WorldCupApi.Data.Models.QueryModels.RequestModel.Group;
using WorldCupApi.Data.Models.QueryModels.ResponseModel.Group;

namespace WorldCupApi.Application.Handler.QueryHandler.Group;

public class GetGroupQueryHandler : IRequestHandler<GetGroupQuery, GetGroupResponse>
{
    private readonly IGroupService _groupService;

    public GetGroupQueryHandler(IGroupService groupService)
    {
        _groupService = groupService;
    }
    
    public async Task<GetGroupResponse> Handle(GetGroupQuery request, CancellationToken cancellationToken)
    {
        return await _groupService.Get(request.Id);
    }
}