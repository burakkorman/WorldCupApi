using MediatR;
using WorldCupApi.Application.Services.Interfaces;
using WorldCupApi.Data.Models.CommandModels.RequestModel.Group;

namespace WorldCupApi.Application.Handler.CommandHandler;

public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, object>
{
    private readonly IGroupService _groupService;

    public CreateGroupCommandHandler(IGroupService groupService)
    {
        _groupService = groupService;
    }
    
    public async Task<object> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        await _groupService.Create(request);
        return true;
    }
}