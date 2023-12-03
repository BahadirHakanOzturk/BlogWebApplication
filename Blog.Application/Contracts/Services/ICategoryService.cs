using Blog.Entities.Concrete;

namespace Blog.Application.Contracts.Services;

public interface ICategoryService
{
    Task AddAsync(Category category);
    Task<IEnumerable<Category>> GetAllAsync();
	Task<IEnumerable<Category>> GetCategoryListWithBlogAsync();
	Task<Category> GetByIdAsync(int id);
    Task DeleteAsync(Category category);
    Task<int> GetTotalCountAsync();
    Task UpdateAsync(Category category);
}
