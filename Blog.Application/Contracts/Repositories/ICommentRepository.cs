﻿using Blog.Application.Contracts.Repositories.Base;
using Blog.Entities.Concrete;

namespace Blog.Application.Contracts.Repositories;

public interface ICommentRepository : IBaseRepository<Comment>
{
	Task<IEnumerable<Comment>> GetListWithBlogAsync();
}
