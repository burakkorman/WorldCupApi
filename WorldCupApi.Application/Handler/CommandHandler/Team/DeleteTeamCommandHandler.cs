using MediatR;
using WorldCupApi.Application.Services.Interfaces;
using WorldCupApi.Data.Models.CommandModels.RequestModel.Team;

namespace WorldCupApi.Application.Handler.CommandHandler.Team;

public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, object>
{
    private readonly ITeamService _teamService;

    public DeleteTeamCommandHandler(ITeamService teamService)
    {
        _teamService = teamService;
    }
    
    public async Task<object> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        await _teamService.Delete(request.Id);
        return true;
    }
}