using MediatR;

namespace WorldCupApi.Data.Models.CommandModels.RequestModel.Group;

public class CreateGroupCommand : IRequest<object>
{
    public string Name { get; set; } = "";
}