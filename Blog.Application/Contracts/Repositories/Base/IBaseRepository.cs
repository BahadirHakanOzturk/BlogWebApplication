using Blog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Contracts.Repositories.Base;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new()
{
    Task DeleteAsync(TEntity entity);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null);
	Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null);
    Task<TEntity> InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
}
