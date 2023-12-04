using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Persistence.Configuration;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
	public void Configure(EntityTypeBuilder<Notification> builder)
	{
		builder.HasData(
			new Notification() { Id = 1, Type = "Günük Toplantı", TypeSymbol = "mdi mdi-calendar", Details = "Lorem ipsum dolor consectetur adipisicing elit.", Date = new DateTime(2022,9,10), Status = true, Color = "preview-icon bg-success" },
			new Notification() { Id = 2, Type = "Doğum Günü", TypeSymbol = "mdi mdi-settings", Details = "Lorem ipsum dolor sit, amet consectetur adipisicing elit.Lorem ipsum dolor sit, amet consectetur adipisicing elit.", Date = new DateTime(2023,1,2), Status = true, Color = "preview-icon bg-warning" },
			new Notification() { Id = 3, Type = "Sistem Bakımı", TypeSymbol = "mdi mdi-link-variant", Details = "Illo, adipisci!", Date = new DateTime(2023,11,10), Status = true, Color = "preview-icon bg-info" },
			new Notification() { Id = 4, Type = "Yeni Yazı", TypeSymbol = "mdi mdi-apple", Details = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Illo, adipisci!", Date = new DateTime(2023,11,11), Status = true, Color = "preview-icon bg-primary" }
			);
	}
}
