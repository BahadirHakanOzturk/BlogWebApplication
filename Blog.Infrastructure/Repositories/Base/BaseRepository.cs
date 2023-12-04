using Blog.Application.Contracts.Repositories.Base;
using Blog.Entities.Abstract;
using Blog.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Infrastructure.Repositories.Base;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
{
    protected readonly BlogContext context;
    public BaseRepository(BlogContext context)
        => this.context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task DeleteAsync(TEntity entity)
    {
        entity.Status = false;
        await context.SaveChangesAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null)
    {
        if (expression == null)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync();

        }
        return await context.Set<TEntity>().FirstOrDefaultAsync(expression);
    }
    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null)
    {
        if (expression == null)
        {
            return await context.Set<TEntity>().Where(x => x.Status == true).ToListAsync();
        }
        return await context.Set<TEntity>().Where(x => x.Status == true).Where(expression).ToListAsync();
    }
    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }
}
