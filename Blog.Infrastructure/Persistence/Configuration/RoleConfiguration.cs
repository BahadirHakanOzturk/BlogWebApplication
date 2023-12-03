using Blog.Entities.Concrete.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Persistence.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<AppRole>
{
	public void Configure(EntityTypeBuilder<AppRole> builder)
	{
		builder.HasData(
			new AppRole() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
			new AppRole() { Id = 2, Name = "Writer", NormalizedName = "WRITER" },
			new AppRole() { Id = 3, Name = "Member", NormalizedName = "MEMBER" }
			);
	}
}
