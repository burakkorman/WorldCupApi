using WorldCupApi.Repository.Entities;

namespace WorldCupApi.Repository.Repositories.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    IQueryable<TEntity> GetAll(bool isActive = true);
    Task<TEntity> GetById(Guid id);
    Task Create(TEntity entity);
    Task Update(Guid id, TEntity entity);
    Task Delete(Guid id);
}