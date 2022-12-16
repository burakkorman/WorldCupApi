using MediatR;

namespace WorldCupApi.Data.Models.CommandModels.RequestModel.Team;

public class DeleteTeamCommand : IRequest<object>
{
    public Guid Id { get; set; }
}