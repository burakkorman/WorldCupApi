using MediatR;
using WorldCupApi.Application.Services.Interfaces;
using WorldCupApi.Data.Models.CommandModels.RequestModel.Team;

namespace WorldCupApi.Application.Handler.CommandHandler.Team;

public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, object>
{
    private readonly ITeamService _teamService;

    public UpdateTeamCommandHandler(ITeamService teamService)
    {
        _teamService = teamService;
    }
    
    public async Task<object> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
    {
        await _teamService.Update(request);
        return true;
    }
}