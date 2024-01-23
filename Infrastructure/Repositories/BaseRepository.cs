using Domain.Common;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly ResTICDbContext Context;

    public BaseRepository(ResTICDbContext context)
    {
        Context = context;
    }
    public void Create(T entity)
    {
        Context.Add(entity);
    }
    public void Update(T entity)
    {
        Context.Update(entity);
    }

    public void Delete(T entity)
    {
        Context.Remove(entity);
    }

    public async Task<T> Get(int id, CancellationToken cancellationToken)
    {
        var entity = await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            throw new Exception($"Entity {nameof(T)} with id {id} not found");
        }
        return entity;
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await Context.Set<T>().ToListAsync(cancellationToken);
    }

    public Task<T> Get(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}