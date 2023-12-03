using Blog.Application.Contracts.Repositories;
using Blog.Application.Contracts.Services;
using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository repository;

    public NotificationService(INotificationRepository repository)
        => this.repository = repository;

    public async Task<IEnumerable<Notification>> GetAllAsync()
        => await repository.GetAllAsync(x => x.Status == true);
}
