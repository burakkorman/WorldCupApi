using MediatR;
using WorldCupApi.Application.Services.Interfaces;
using WorldCupApi.Data.Models.CommandModels.RequestModel.Group;

namespace WorldCupApi.Application.Handler.CommandHandler;

public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, object>
{
    private readonly IGroupService _groupService;

    public UpdateGroupCommandHandler(IGroupService groupService)
    {
        _groupService = groupService;
    }
    
    public async Task<object> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        await _groupService.Update(request);
        return true;
    }
}