using MediatR;

namespace WorldCupApi.Data.Models.CommandModels.RequestModel.Team;

public class UpdateTeamCommand : IRequest<object>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid GroupId { get; set; }
}