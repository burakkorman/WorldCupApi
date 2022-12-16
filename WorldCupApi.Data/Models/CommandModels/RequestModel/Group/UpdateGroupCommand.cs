using MediatR;

namespace WorldCupApi.Data.Models.CommandModels.RequestModel.Group;

public class UpdateGroupCommand : IRequest<object>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}