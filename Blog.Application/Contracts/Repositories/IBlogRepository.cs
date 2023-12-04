using Blog.Application.Contracts.Repositories.Base;

namespace Blog.Application.Contracts.Repositories;

public interface IBlogRepository : IBaseRepository<Entities.Concrete.Blog>
{
    Task<IEnumerable<Entities.Concrete.Blog>> GetListWithCategoryAsync();
    Task<IEnumerable<Entities.Concrete.Blog>> GetListWithCategoryByWriter(int id);
}