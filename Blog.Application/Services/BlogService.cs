using Blog.Application.Contracts.Repositories;
using Blog.Application.Contracts.Services;

namespace Blog.Application.Services;

public class BlogService : IBlogService
{
    private readonly IBlogRepository repository;

    public BlogService(IBlogRepository repository)
        => this.repository = repository;

    public async Task AddAsync(Entities.Concrete.Blog blog)
        => await repository.InsertAsync(blog);

    public async Task DeleteAsync(Entities.Concrete.Blog blog)
        => await repository.DeleteAsync(blog);

    public async Task<IEnumerable<Entities.Concrete.Blog>> GetAllAsync()
        => await repository.GetAllAsync();

    public async Task<IEnumerable<Entities.Concrete.Blog>> GetBlogListWithCategoryAsync()
        => await repository.GetListWithCategoryAsync();

    public async Task<IEnumerable<Entities.Concrete.Blog>> GetLast10BlogsWithCategoryAsync()
    {
        var blogs = await repository.GetListWithCategoryAsync();
        return blogs.OrderByDescending(x => x.CreateDate).Take(10);
    }

    public async Task<IEnumerable<Entities.Concrete.Blog>> GetListWithCategoryByWriterAsync(int id)
        => await repository.GetListWithCategoryByWriter(id);

    public async Task<Entities.Concrete.Blog> GetByIdAsync(int id)
        => await repository.GetAsync(x => x.Id == id);

    public async Task<IEnumerable<Entities.Concrete.Blog>> GetLast3BlogsAsync()
    {
        var blogs = await repository.GetAllAsync();
        var last3blogs = blogs.OrderByDescending(x => x.CreateDate).Take(3);
        return last3blogs;
    }

    public async Task<IEnumerable<Entities.Concrete.Blog>> GetListByWriterAsync(int id)
        => await repository.GetAllAsync(x => x.UserId == id);

    public async Task<int> GetTotalCountAsync()
    {
        var blogs = await repository.GetAllAsync();
        return blogs.Count();
    }

    public async Task<int> GetTotalCountByWriterAsync(int id)
    {
        var blogs = await repository.GetAllAsync(x => x.UserId == id);
        return blogs.Count();
    }

    public async Task UpdateAsync(Entities.Concrete.Blog blog)
        => await repository.UpdateAsync(blog);
}
