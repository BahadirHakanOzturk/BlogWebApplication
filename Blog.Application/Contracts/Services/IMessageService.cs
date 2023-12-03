using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Contracts.Services;

public interface IMessageService
{
	Task AddAsync(Message message);
	Task<IEnumerable<Message>> GetByIdAsync(int id);
	Task<IEnumerable<Message>> GetInboxByWriterAsync(int id);
	Task<IEnumerable<Message>> GetOutboxByWriterAsync(int id);
}
