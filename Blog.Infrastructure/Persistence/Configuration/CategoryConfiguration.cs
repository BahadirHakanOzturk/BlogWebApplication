using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Persistence.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.HasData(
			new Category { Id = 1, Name = "Yazılım", Status = true },
			new Category { Id = 2, Name = "Oyun", Status = true },
			new Category { Id = 3, Name = "Film", Status = true },
			new Category { Id = 4, Name = "Teknoloji", Status = true }
			);
	}
}
