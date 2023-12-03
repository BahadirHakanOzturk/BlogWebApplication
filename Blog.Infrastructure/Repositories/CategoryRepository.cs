using Blog.Application.Contracts.Repositories;
using Blog.Entities.Concrete;
using Blog.Infrastructure.Persistence.Context;
using Blog.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(BlogContext context) : base(context)
    {
    }

	public async Task<IEnumerable<Category>> GetListWithBlogAsync()
		=> await base.context.Categories.Include(x => x.Blogs).ToListAsync();
}
