using MediatR;
using WorldCupApi.Data.Models.QueryModels.ResponseModel.Team;

namespace WorldCupApi.Data.Models.QueryModels.RequestModel.Team;

public class GetAllTeamsQuery : IRequest<List<GetTeamResponse>>
{
    
}