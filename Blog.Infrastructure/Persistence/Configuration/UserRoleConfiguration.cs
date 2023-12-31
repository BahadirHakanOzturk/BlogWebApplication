﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Persistence.Configuration;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
{
	public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
	{
		builder.HasData(
			 new IdentityUserRole<int>() { UserId = 1, RoleId = 1 },
			 new IdentityUserRole<int>() { UserId = 2, RoleId = 2 },
			 new IdentityUserRole<int>() { UserId = 3, RoleId = 2 },
			 new IdentityUserRole<int>() { UserId = 4, RoleId = 2 },
			 new IdentityUserRole<int>() { UserId = 5, RoleId = 3 }
			);
	}
}
