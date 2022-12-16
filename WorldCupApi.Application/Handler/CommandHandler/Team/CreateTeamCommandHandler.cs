using MediatR;
using WorldCupApi.Application.Services.Interfaces;
using WorldCupApi.Data.Models.CommandModels.RequestModel.Team;

namespace WorldCupApi.Application.Handler.CommandHandler.Team;

public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, object>
{
    private readonly ITeamService _teamService;

    public CreateTeamCommandHandler(ITeamService teamService)
    {
        _teamService = teamService;
    }
    public async Task<object> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        await _teamService.Create(request);
        return true;
    }
}