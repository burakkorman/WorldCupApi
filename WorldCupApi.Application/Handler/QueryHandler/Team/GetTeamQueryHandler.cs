using MediatR;
using WorldCupApi.Application.Services.Interfaces;
using WorldCupApi.Data.Models.QueryModels.RequestModel.Team;
using WorldCupApi.Data.Models.QueryModels.ResponseModel.Team;

namespace WorldCupApi.Application.Handler.QueryHandler.Team;

public class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, GetTeamResponse>
{
    private readonly ITeamService _teamService;

    public GetTeamQueryHandler(ITeamService teamService)
    {
        _teamService = teamService;
    }
    
    public async Task<GetTeamResponse> Handle(GetTeamQuery request, CancellationToken cancellationToken)
    {
        return await _teamService.Get(request.Id);
    }
}