﻿using Blog.Application.Contracts.Repositories;
using Blog.Entities.Concrete;
using Blog.Infrastructure.Persistence.Context;
using Blog.Infrastructure.Repositories.Base;

namespace Blog.Infrastructure.Repositories;

public class NewsLetterRepository : BaseRepository<NewsLetter>, INewsLetterRepository
{
	public NewsLetterRepository(BlogContext context) : base(context)
	{
	}
}
