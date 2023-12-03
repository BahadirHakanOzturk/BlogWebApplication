using Microsoft.AspNetCore.Identity;

namespace Blog.Entities.Concrete.User;

public class AppUser : IdentityUser<int>
{
    public string NameSurname { get; set; }
    public string? Title { get; set; }
    public string? About { get; set; }
    public string? ImageUrl { get; set; }
	public virtual ICollection<Blog> Blogs { get; set; }
	public virtual ICollection<Message> InboxMessages { get; set; }
	public virtual ICollection<Message> OutboxMessages { get; set; }
}
