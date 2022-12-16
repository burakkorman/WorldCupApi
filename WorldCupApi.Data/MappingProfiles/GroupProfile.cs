using AutoMapper;
using WorldCupApi.Data.Models.CommandModels.RequestModel.Group;
using WorldCupApi.Data.Models.QueryModels.ResponseModel.Group;
using WorldCupApi.Repository.Entities;

namespace WorldCupApi.Data.MappingProfiles;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<Group, GetGroupResponse>();
        CreateMap<CreateGroupCommand, Group>()
            .ForMember(dest => dest.Id, 
                opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.CreatedDate, 
                opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.IsActive, 
                opt => opt.MapFrom(src => true));
    }
}