using AutoMapper;
using WorldCupApi.Data.Models.CommandModels.RequestModel.Team;
using WorldCupApi.Data.Models.QueryModels.ResponseModel.Team;
using WorldCupApi.Repository.Entities;

namespace WorldCupApi.Data.MappingProfiles;

public class TeamProfile : Profile
{
    public TeamProfile()
    {
        CreateMap<Team, GetTeamResponse>()
            .ForMember(dest => dest.GroupName, 
                opt => opt.MapFrom(src => src.Group.Name));
        CreateMap<CreateTeamCommand, Team>()
            .ForMember(dest => dest.Id, 
                opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.CreatedDate, 
                opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.IsActive, 
                opt => opt.MapFrom(src => true));
    }
}