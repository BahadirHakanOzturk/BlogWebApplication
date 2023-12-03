using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Persistence.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
	public void Configure(EntityTypeBuilder<Comment> builder)
	{
		builder.HasData(
			new Comment { Id = 1, UserName = "Ali Yıldırım", Title = "Quisquam vero esse nostrum", Content = "Illo, adipisci! Illo, adipisci!", Date = new DateTime(2023,2,18), Status = true, BlogId = 4 },
			new Comment { Id = 2, UserName = "Gizem Çınar", Title = "voluptas modi aperiam dolore", Content = "Lorem ipsum dolor sit, amet consectetur.", Date = new DateTime(2022,6,2), Status = true, BlogId = 3 },
			new Comment { Id = 3, UserName = "Aslı Yıldız", Title = "magnam qui aspernatur", Content = "Lorem ipsum dolor sit, amet consectetur. ipsum dolor sit.", Date = new DateTime(2023,7,22), Status = true, BlogId = 2 },
			new Comment { Id = 4, UserName = "Mert Kaya", Title = "Quisquam vero esse nostrum", Content = "Lorem ipsum dolor sit, amet consectetur.", Date = new DateTime(2023,4,1), Status = true, BlogId = 6 }
			);
	}
}
