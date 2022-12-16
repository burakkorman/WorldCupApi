using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorldCupApi.Data.Models.CommandModels.RequestModel.Group;
using WorldCupApi.Data.Models.QueryModels.RequestModel.Group;

namespace WorldCupApi.Controllers;

[Route("api/group")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public GroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllGroupsQuery());
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]GetGroupQuery request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateGroupCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateGroupCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteGroupCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}