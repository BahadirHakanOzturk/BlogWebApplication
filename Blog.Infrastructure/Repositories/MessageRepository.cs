using Blog.Application.Contracts.Repositories;
using Blog.Entities.Concrete;
using Blog.Infrastructure.Persistence.Context;
using Blog.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
	public MessageRepository(BlogContext context) : base(context)
	{
	}

    public async Task<IEnumerable<Message>> GetInboxListWithWriterAsync(int id)
		=> await context.Messages.Include(x => x.Sender).Where(x => x.ReceiverId == id).ToListAsync();

	public async Task<IEnumerable<Message>> GetOutboxListWithWriterAsync(int id)
		=> await context.Messages.Include(x => x.Receiver).Where(x => x.SenderId == id).ToListAsync();
}
