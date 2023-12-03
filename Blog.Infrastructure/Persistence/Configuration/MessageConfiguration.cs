using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Persistence.Configuration;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
	public void Configure(EntityTypeBuilder<Message> builder)
	{
		builder.HasData(
			new Message() { Id = 1, SenderId = 2, ReceiverId = 1, Subject = "ipsum", Details = "Lorem ipsum dolor sit amet.", Date = new DateTime(2023,6,22), Status = true },
			new Message() { Id = 2, SenderId = 3, ReceiverId = 1, Subject = "ipsum", Details = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolores, quod.", Date = new DateTime(2023,9,15), Status = true },
			new Message() { Id = 3, SenderId = 1, ReceiverId = 2, Subject = "Similique", Details = "Similique dolorem laboriosam culpa nisi?", Date = new DateTime(2023,9,20), Status = true },
			new Message() { Id = 4, SenderId = 1, ReceiverId = 3, Subject = "ullam", Details = "ullam dolorem natus, incidunt ad dolore iste culpa sapiente numquam.", Date = new DateTime(2023,10,11), Status = true },
			new Message() { Id = 5, SenderId = 2, ReceiverId = 1, Subject = "Lorem", Details = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolores, quod.", Date = new DateTime(2023,8,9), Status = true },
			new Message() { Id = 6, SenderId = 2, ReceiverId = 1, Subject = "aliquid", Details = "Lorem ipsum dolor consectetur adipisicing elit. sit amet consectetur adipisicing elit. Dolores, quod.", Date = new DateTime(2023,6,22), Status = true },
			new Message() { Id = 7, SenderId = 1, ReceiverId = 3, Subject = "consectetur", Details = "Lorem ipsum dolorametet modi aliquid maxime placeat architecto. odio quae enim! sit amet consectetur adipisicing elit. Dolores, quod.", Date = new DateTime(2023,8,10), Status = true },
			new Message() { Id = 8, SenderId = 2, ReceiverId = 4, Subject = "Lorem", Details = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolores, amet odio quae enim quod.", Date = new DateTime(2023,5,5), Status = true },
			new Message() { Id = 9, SenderId = 2, ReceiverId = 3, Subject = "aliquid", Details = "Lorem ipsum dolor sit amet consectetur amet odio quae enim adipisicing elit. Dolores, quod.", Date = new DateTime(2023,7,27), Status = true },
			new Message() { Id = 10, SenderId = 2, ReceiverId = 4, Subject = "doloret", Details = "Lorem ipsum doloret modi aliquid maxime placeat architecto. sit amet consectetur adipisicing elit. Dolores, quod.", Date = new DateTime(2023,10,19), Status = true }
			);

		builder.HasOne(x => x.Sender).WithMany(y => y.OutboxMessages).HasForeignKey(z => z.SenderId).OnDelete(DeleteBehavior.ClientSetNull);
		builder.HasOne(x => x.Receiver).WithMany(y => y.InboxMessages).HasForeignKey(z => z.ReceiverId).OnDelete(DeleteBehavior.ClientSetNull);
	}
}
