using Blog.Application.Contracts.Repositories.Base;
using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Contracts.Repositories;

public interface IMessageRepository : IBaseRepository<Message>
{
    Task<IEnumerable<Message>> GetInboxListWithWriterAsync(int id);
    Task<IEnumerable<Message>> GetOutboxListWithWriterAsync(int id);
}
