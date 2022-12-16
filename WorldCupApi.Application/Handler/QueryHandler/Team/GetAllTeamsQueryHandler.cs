using MediatR;
using WorldCupApi.Application.Services.Interfaces;
using WorldCupApi.Data.Models.QueryModels.RequestModel.Team;
using WorldCupApi.Data.Models.QueryModels.ResponseModel.Team;

namespace WorldCupApi.Application.Handler.QueryHandler.Team;

public class GetAllTeamsQueryHandler : IRequestHandler<GetAllTeamsQuery, List<GetTeamResponse>>
{
    private readonly ITeamService _teamService;

    public GetAllTeamsQueryHandler(ITeamService teamService)
    {
        _teamService = teamService;
    }
    
    public async Task<List<GetTeamResponse>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
    {
        return await _teamService.GetAll();
    }
}