using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorldCupApi.Data.Models.CommandModels.RequestModel.Team;
using WorldCupApi.Data.Models.QueryModels.RequestModel.Team;

namespace WorldCupApi.Controllers;

[Route("api/team")]
[ApiController]
public class TeamController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeamController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllTeamsQuery());
        return Ok(result);
    }
    
    [HttpGet("getById")]
    public async Task<IActionResult> GetById([FromQuery]GetTeamQuery request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateTeamCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateTeamCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteTeamCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}