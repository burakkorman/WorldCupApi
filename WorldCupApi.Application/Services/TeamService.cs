using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorldCupApi.Application.Services.Interfaces;
using WorldCupApi.Data.Models.CommandModels.RequestModel.Team;
using WorldCupApi.Data.Models.QueryModels.ResponseModel.Team;
using WorldCupApi.Repository.Entities;
using WorldCupApi.Repository.Repositories.Interfaces;

namespace WorldCupApi.Application.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly IMapper _mapper;

    public TeamService(ITeamRepository teamRepository, IGroupRepository groupRepository, IMapper mapper)
    {
        _teamRepository = teamRepository;
        _groupRepository = groupRepository;
        _mapper = mapper;
    }
    
    public async Task<List<GetTeamResponse>> GetAll()
    {
        var result = await _teamRepository.GetAllWithGroup();
        return _mapper.Map<List<GetTeamResponse>>(result);
    }

    public async Task<GetTeamResponse> Get(Guid id)
    {
        var team = await _teamRepository.GetWithGroup(id);
        
        if(team is null)
            throw new Exception("Takım bulunamadı");

        return _mapper.Map<GetTeamResponse>(team);
    }

    public async Task Create(CreateTeamCommand model)
    {
        var totalTeamCount = await _groupRepository.GetTeamCountById(model.GroupId);

        if (totalTeamCount >= 4)
            throw new Exception("Takım sayısı 4'den fazla olamaz");

        var team = _mapper.Map<Team>(model);
        await _teamRepository.Create(team);
    }

    public async Task Update(UpdateTeamCommand model)
    {
        var team = await _teamRepository.GetById(model.Id);
        
        team.Name = model.Name;
        team.GroupId = model.GroupId;

        await _teamRepository.Update(team.Id, team);
    }

    public async Task Delete(Guid id)
    {
        await _teamRepository.Delete(id);
    }
}