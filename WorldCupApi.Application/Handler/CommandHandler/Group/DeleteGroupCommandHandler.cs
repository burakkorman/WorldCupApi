using MediatR;
using WorldCupApi.Application.Services.Interfaces;
using WorldCupApi.Data.Models.CommandModels.RequestModel.Group;

namespace WorldCupApi.Application.Handler.CommandHandler;

public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, object>
{
    private readonly IGroupService _groupService;

    public DeleteGroupCommandHandler(IGroupService groupService)
    {
        _groupService = groupService;
    }
    
    public async Task<object> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        await _groupService.Delete(request.Id);
        return true;
    }
}