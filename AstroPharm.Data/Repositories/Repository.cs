using AstroPharm.Data.DbContexts;
using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Commons;
using AstroPharm.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _dbSet = _appDbContext.Set<TEntity>();
    }
    public async Task<bool> DeleteAsync(long id)
    {
        var entity_entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (entity_entity == null)
        {
            throw new AstoPharmException(404, "User not found");
        }
        _dbSet.Remove(entity_entity);
        _appDbContext.SaveChanges();
        return true;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var entity_entity = await _dbSet.AddAsync(entity);
        _appDbContext.SaveChanges();
        return entity_entity.Entity;
    }

    public IQueryable<TEntity> SelectAll() => _dbSet;

    public async Task<TEntity> SelectByIdAsync(long id)
    {
        var entity_entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (entity_entity == null)
        {
            throw new AstoPharmException(404, "User not found");
        }
        return entity_entity;
    }

    public  async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entity_entity = _appDbContext.Update(entity);
        _appDbContext.SaveChanges();
        return entity_entity.Entity;
    }
}
