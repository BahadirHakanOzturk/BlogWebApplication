using Blog.Entities.Concrete.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<AppUser>
{
	public void Configure(EntityTypeBuilder<AppUser> builder)
	{
		var hasher = new PasswordHasher<AppUser>();
		builder.HasData(
			new AppUser() { Id = 1, NameSurname = "Bahadır Hakan Öztürk", About = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Illo, adipisci!", UserName = "bahadirhakanozturk", NormalizedUserName = "BAHADIRHAKANOZTURK", Email = "bahadirhakanozturk@blog.com", NormalizedEmail = "BAHADIRHAKANOZTURK@BLOG.COM", EmailConfirmed = true, PhoneNumberConfirmed = true, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0, PasswordHash = hasher.HashPassword(null, "123456Aa*"), SecurityStamp = "D2C7BG653KANTFOB6NNHCOSN2R7GM27B", Title = ".Net Geliştiricisi", ImageUrl = "/Admin/img/a1.jpg" },
			new AppUser() { Id = 2, NameSurname = "Elif Betül Öztürk", About = "Lorem ipsum dolor sit, amet Lorem ipsum dolor sit, amet consectetur adipisicing consectetur adipisicing elit. Illo, adipisci!", UserName = "elifbetulozturk", NormalizedUserName = "ELIFBETULOZTURK", Email = "elifbetulozturk@blog.com", NormalizedEmail = "ELIFBETULOZTURK@BLOG.COM", EmailConfirmed = true, PhoneNumberConfirmed = true, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0, PasswordHash = hasher.HashPassword(null, "123456Bb*"), SecurityStamp = "D2C7BG653KANTFOB6NNHCOSN2R7GM27A", Title = "Yazılım Geliştiricisi", ImageUrl = "/web/images/t2.jpg" },
			new AppUser() { Id = 3, NameSurname = "Cem Kaya", About = "Lorem ipsum dolor consectetur adipisicing elit.  sit, amet consectetur adipisicing elit. Illo, adipisci!", UserName = "cemkaya", NormalizedUserName = "CEMKAYA", Email = "cemkaya@blog.com", NormalizedEmail = "CEMKAYA@BLOG.COM", EmailConfirmed = true, PhoneNumberConfirmed = true, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0, PasswordHash = hasher.HashPassword(null, "123456Cc*"), SecurityStamp = "D2C7BG653KANTFOB6NNHCOSN2R7GM27C", Title = "Yazar", ImageUrl = "/web/images/t3.jpg" },
			new AppUser() { Id = 4, NameSurname = "Ayşe Çınar", About = "Lorem ipsum dolor sit, Lorem ipsum dolor sit, amet consectetur adipisicing elit. Illo, adipisci!", UserName = "aysecinar", NormalizedUserName = "AYSECINAR", Email = "aysecinar@blog.com", NormalizedEmail = "AYSECINAR@BLOG.COM", EmailConfirmed = true, PhoneNumberConfirmed = true, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0, PasswordHash = hasher.HashPassword(null, "123456Dd*"), SecurityStamp = "D2C7BG653KANTFOB6NNHCOSN2R7GM27D", ImageUrl = "/web/images/t4.jpg" },
			new AppUser() { Id = 5, NameSurname = "Hakkı Can", About = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Illo, adipisci! Illo, adipisci! Illo, adipisci!", UserName = "hakkican", NormalizedUserName = "HAKKICAN", Email = "hakkican@blog.com", NormalizedEmail = "HAKKICAN@BLOG.COM", EmailConfirmed = true, PhoneNumberConfirmed = true, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0, PasswordHash = hasher.HashPassword(null, "123456Ee*"), SecurityStamp = "D2C7BG653KANTFOB6NNHCOSN2R7GM27S", ImageUrl = "/Admin/img/a4.jpg" }
			);
	}
}
