using InferStructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InferStructure.Repositories;

public abstract class BaseRepository<TEntity> where TEntity : class
{
    private AppDbContext _appDbContext;

    protected DbSet<TEntity> _entities;

    protected BaseRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _entities = appDbContext.Set<TEntity>();
    }
}