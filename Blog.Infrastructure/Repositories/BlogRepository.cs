using Blog.Application.Contracts.Repositories;
using Blog.Infrastructure.Persistence.Context;
using Blog.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class BlogRepository : BaseRepository<Entities.Concrete.Blog>, IBlogRepository
{
    public BlogRepository(BlogContext context) : base(context)
    {
    }

	public async Task<IEnumerable<Entities.Concrete.Blog>> GetListWithCategoryAsync()
		=> await base.context.Blogs.Include(x => x.Category).ToListAsync();

	public async Task<IEnumerable<Entities.Concrete.Blog>> GetListWithCategoryByWriter(int id)
		=> await base.context.Blogs.Include(x => x.Category).Where(x => x.UserId == id && x.Status == true).ToListAsync();
}
