using Blog.Application.Contracts.Repositories;
using Blog.Application.Contracts.Services;
using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services;

public class MessageService : IMessageService
{
	private readonly IMessageRepository repository;

	public MessageService(IMessageRepository repository)
		=> this.repository = repository;

    public async Task AddAsync(Message message)
		=> await repository.InsertAsync(message);

    public async Task<IEnumerable<Message>> GetByIdAsync(int id)
		=> await repository.GetAllAsync(x => x.Id == id);

    public async Task<IEnumerable<Message>> GetInboxByWriterAsync(int id)
		=> await repository.GetInboxListWithWriterAsync(id);

    public async Task<IEnumerable<Message>> GetOutboxByWriterAsync(int id)
		=> await repository.GetOutboxListWithWriterAsync(id);
}
