using Blog.Application.Contracts.Repositories.Base;
using Blog.Entities.Concrete;

namespace Blog.Application.Contracts.Repositories;

public interface IMessageRepository : IBaseRepository<Message>
{
    Task<IEnumerable<Message>> GetInboxListWithWriterAsync(int id);
    Task<IEnumerable<Message>> GetOutboxListWithWriterAsync(int id);
}
