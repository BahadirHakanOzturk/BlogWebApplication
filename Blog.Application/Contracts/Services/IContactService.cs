using Blog.Entities.Concrete;

namespace Blog.Application.Contracts.Services;

public interface IContactService
{
    Task AddAsync(Contact contact);
    Task<IEnumerable<Contact>> GetAllAsync();
}
