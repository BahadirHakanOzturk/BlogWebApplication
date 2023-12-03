using Blog.Application.Contracts.Repositories.Base;
using Blog.Entities.Concrete;

namespace Blog.Application.Contracts.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
	Task<IEnumerable<Category>> GetListWithBlogAsync();
}
