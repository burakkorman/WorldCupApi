using MediatR;
using WorldCupApi.Data.Models.QueryModels.ResponseModel.Team;

namespace WorldCupApi.Data.Models.QueryModels.RequestModel.Team;

public class GetTeamQuery : IRequest<GetTeamResponse>
{
    public Guid Id { get; set; }
}