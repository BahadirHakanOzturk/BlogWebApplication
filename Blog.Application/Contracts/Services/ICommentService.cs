using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Contracts.Services;

public interface ICommentService
{
    Task AddAsync(Comment comment);
    Task DeleteAsync(Comment comment);
	Task<IEnumerable<Comment>> GetAllAsync();
	Task<IEnumerable<Comment>> GetAllByIdAsync(int id);
	Task<Comment> GetByIdAsync(int id);
	Task<IEnumerable<Comment>> GetCommentListWithBlogAsync();
}
