using MediatR;

namespace WorldCupApi.Data.Models.CommandModels.RequestModel.Team;

public class CreateTeamCommand : IRequest<object>
{
    public string Name { get; set; }
    public Guid GroupId { get; set; }
}