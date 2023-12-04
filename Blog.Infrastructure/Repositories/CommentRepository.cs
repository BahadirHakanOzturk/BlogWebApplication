using Blog.Application.Contracts.Repositories;
using Blog.Entities.Concrete;
using Blog.Infrastructure.Persistence.Context;
using Blog.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(BlogContext context) : base(context)
    {
    }

	public async Task<IEnumerable<Comment>> GetListWithBlogAsync()
		=> await base.context.Comments.Include(x => x.Blog).ToListAsync();
}
