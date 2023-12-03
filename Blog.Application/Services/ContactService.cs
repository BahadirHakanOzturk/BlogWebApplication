using Blog.Application.Contracts.Repositories;
using Blog.Application.Contracts.Services;
using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services;

public class ContactService : IContactService
{
	private readonly IContactRepository repository;

	public ContactService(IContactRepository repository)
		=> this.repository = repository;

    public async Task AddAsync(Contact contact)
		=> await repository.InsertAsync(contact);

    public async Task<IEnumerable<Contact>> GetAllAsync()
		=> await repository.GetAllAsync(x => x.Status == true);
}
