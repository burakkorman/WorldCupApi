using MediatR;

namespace WorldCupApi.Data.Models.CommandModels.RequestModel.Group;

public class DeleteGroupCommand : IRequest<object>
{
    public Guid Id { get; set; }
}