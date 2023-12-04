using Blog.Entities.Concrete;
using Blog.Entities.Concrete.User;
using Blog.Infrastructure.Persistence.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Persistence.Context;

public class BlogContext : IdentityDbContext<AppUser, AppRole, int>
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
	}

    public DbSet<Entities.Concrete.Blog> Blogs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<NewsLetter> NewsLetters { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Message> Messages { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        modelBuilder.ApplyConfiguration(new CategoryConfiguration())
                    .ApplyConfiguration(new BlogConfiguration())
                    .ApplyConfiguration(new CommentConfiguration())
                    .ApplyConfiguration(new NotificationConfiguration())
                    .ApplyConfiguration(new MessageConfiguration())
                    .ApplyConfiguration(new UserConfiguration())
                    .ApplyConfiguration(new RoleConfiguration())
                    .ApplyConfiguration(new UserRoleConfiguration());

		base.OnModelCreating(modelBuilder);
	}
}
