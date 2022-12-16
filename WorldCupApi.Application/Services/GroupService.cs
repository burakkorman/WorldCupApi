using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorldCupApi.Application.Services.Interfaces;
using WorldCupApi.Data.Models.CommandModels.RequestModel.Group;
using WorldCupApi.Data.Models.QueryModels.ResponseModel.Group;
using WorldCupApi.Repository.Entities;
using WorldCupApi.Repository.Repositories.Interfaces;

namespace WorldCupApi.Application.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IMapper _mapper;

    public GroupService(IGroupRepository groupRepository, IMapper mapper)
    {
        _groupRepository = groupRepository;
        _mapper = mapper;
    }
    
    public async Task<List<GetGroupResponse>> GetAll()
    {
        var result = await _groupRepository.GetAll().OrderBy(x => x.Name).ToListAsync();
        return _mapper.Map<List<GetGroupResponse>>(result);
    }

    public async Task<GetGroupResponse> Get(Guid id)
    {
        var group = await _groupRepository.GetById(id);
        return _mapper.Map<GetGroupResponse>(group) ?? throw new Exception("Grup bulunamadı");
    }

    public async Task Create(CreateGroupCommand model)
    {
        var totalGroupCount = await _groupRepository.GetTotalGroupCount();

        if (totalGroupCount >= 8)
            throw new Exception("Grup sayısı 8'den fazla olamaz");

        var group = _mapper.Map<Group>(model);
        await _groupRepository.Create(group);
    }

    public async Task Update(UpdateGroupCommand model)
    {
        var group = await _groupRepository.GetById(model.Id);
        group.Name = model.Name;

        await _groupRepository.Update(group.Id, group);
    }

    public async Task Delete(Guid id)
    {
        await _groupRepository.Delete(id);
    }
}