using Blog.Entities.Abstract;
using Blog.Entities.Concrete.User;

namespace Blog.Entities.Concrete;

public class Message : BaseEntity
{
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string Subject { get; set; }
    public string Details { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public virtual AppUser Sender { get; set; }
    public virtual AppUser Receiver { get; set; }
}
