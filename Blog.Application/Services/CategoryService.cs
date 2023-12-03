using Blog.Application.Contracts.Repositories;
using Blog.Application.Contracts.Services;
using Blog.Entities.Concrete;

namespace Blog.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository repository;

    public CategoryService(ICategoryRepository repository)
        => this.repository = repository;

    public async Task AddAsync(Category category)
        => await repository.InsertAsync(category);

    public async Task DeleteAsync(Category category)
        => await repository.DeleteAsync(category);

    public async Task<IEnumerable<Category>> GetAllAsync()
        => await repository.GetAllAsync(x => x.Status == true);

    public async Task<IEnumerable<Category>> GetCategoryListWithBlogAsync()
       => await repository.GetListWithBlogAsync();

	public async Task<Category> GetByIdAsync(int id)
        => await repository.GetAsync(x => x.Id == id);

	public async Task<int> GetTotalCountAsync()
	{
		var categories = await repository.GetAllAsync();
		return categories.Count();
	}

	public async Task UpdateAsync(Category category)
        => await repository.UpdateAsync(category);
}
