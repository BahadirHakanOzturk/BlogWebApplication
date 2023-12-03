using Blog.Application.Contracts.Repositories;
using Blog.Application.Contracts.Services;
using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services;

public class NewsLetterService : INewsLetterService
{
	private readonly INewsLetterRepository repository;

	public NewsLetterService(INewsLetterRepository repository)
		=> this.repository = repository;

    public async Task AddAsync(NewsLetter newsLetter)
		=> await repository.InsertAsync(newsLetter);
}
