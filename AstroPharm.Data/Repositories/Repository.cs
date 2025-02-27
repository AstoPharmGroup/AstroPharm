using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Commons;

namespace AstroPharm.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> InsertAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> SelectAll()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> SelectByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
