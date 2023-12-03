using Blog.Application.Contracts.Repositories;
using Blog.Application.Contracts.Services;
using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services;

public class CommentService : ICommentService
{
	private readonly ICommentRepository repository;

	public CommentService(ICommentRepository repository)
		=> this.repository = repository;

    public async Task AddAsync(Comment comment)
		=> await repository.InsertAsync(comment);

	public async Task DeleteAsync(Comment comment)
		=> await repository.DeleteAsync(comment);

	public async Task<IEnumerable<Comment>> GetAllAsync()
		=> await repository.GetAllAsync(x => x.Status == true);

    public async Task<IEnumerable<Comment>> GetAllByIdAsync(int id)
		=> await repository.GetAllAsync(x => x.BlogId == id);

	public async Task<Comment> GetByIdAsync(int id)
		=> await repository.GetAsync(x => x.Id == id);

    public async Task<IEnumerable<Comment>> GetCommentListWithBlogAsync()
		=> await repository.GetListWithBlogAsync();
}
