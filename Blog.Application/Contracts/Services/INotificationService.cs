using Blog.Entities.Concrete;

namespace Blog.Application.Contracts.Services;

public interface INotificationService
{
    Task<IEnumerable<Notification>> GetAllAsync();
}
