using Microsoft.EntityFrameworkCore;
using WorldCupApi.Repository.Entities;
using WorldCupApi.Repository.Repositories.Interfaces;

namespace WorldCupApi.Repository.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    public readonly DbSet<TEntity> _entities;
    private readonly WorldCupApiDbContext _context;

    public GenericRepository(WorldCupApiDbContext context)
    {
        _entities = context.Set<TEntity>();
        _context = context;
    }

    public IQueryable<TEntity> GetAll(bool isActive = true)
    {
        return _context.Set<TEntity>().AsNoTracking().Where(x => x.IsActive == isActive);
    }

    public async Task<TEntity> GetById(Guid id)
    {
        return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Create(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Guid id, TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var entity = await GetById(id);
        entity.IsActive = false;
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }
}