using Blog.Application.Contracts.Repositories;
using Blog.Application.Contracts.Services;
using Blog.Application.Services;
using Blog.Entities.Concrete.User;
using Blog.Infrastructure.Persistence.Context;
using Blog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure;

public static class PersistenceServiceRegistration
{
	public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<BlogContext>(
								options => options.UseSqlServer(configuration.GetConnectionString("BlogProject"))
								.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));


		services.AddIdentity<AppUser, AppRole>(x =>
		{
			x.Password.RequireUppercase = false;
			x.Password.RequireNonAlphanumeric = false;
		})
		.AddEntityFrameworkStores<BlogContext>();


		services.AddScoped<ICategoryRepository, CategoryRepository>();
		services.AddScoped<ICategoryService, CategoryService>();
		services.AddScoped<IBlogRepository, BlogRepository>();
		services.AddScoped<IBlogService, BlogService>();
		services.AddScoped<ICommentRepository, CommentRepository>();
		services.AddScoped<ICommentService, CommentService>();
		services.AddScoped<INewsLetterRepository, NewsLetterRepository>();
		services.AddScoped<INewsLetterService, NewsLetterService>();
		services.AddScoped<IContactRepository, ContactRepository>();
		services.AddScoped<IContactService, ContactService>();
		services.AddScoped<INotificationRepository, NotificationRepository>();
		services.AddScoped<INotificationService, NotificationService>();
		services.AddScoped<IMessageRepository, MessageRepository>();
		services.AddScoped<IMessageService, MessageService>();

		return services;
	}
}
