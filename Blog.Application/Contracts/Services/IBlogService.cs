namespace Blog.Application.Contracts.Services;

public interface IBlogService
{
    Task AddAsync(Entities.Concrete.Blog blog);
	Task DeleteAsync(Entities.Concrete.Blog blog);
	Task<IEnumerable<Entities.Concrete.Blog>> GetAllAsync();
    Task<IEnumerable<Entities.Concrete.Blog>> GetBlogListWithCategoryAsync();
    Task<IEnumerable<Entities.Concrete.Blog>> GetLast10BlogsWithCategoryAsync();
    Task<IEnumerable<Entities.Concrete.Blog>> GetListWithCategoryByWriterAsync(int id);
    Task<Entities.Concrete.Blog> GetByIdAsync(int id);
    Task<IEnumerable<Entities.Concrete.Blog>> GetLast3BlogsAsync();
    Task<IEnumerable<Entities.Concrete.Blog>> GetListByWriterAsync(int id);
    Task<int> GetTotalCountAsync();
    Task<int> GetTotalCountByWriterAsync(int id);
    Task UpdateAsync(Entities.Concrete.Blog blog);
}
