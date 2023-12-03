using Blog.Application.Contracts.Services;
using Blog.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[AllowAnonymous]
public class ContactController : Controller
{
	private readonly IContactService contactService;

	public ContactController(IContactService contactService)
		=> this.contactService = contactService;

	public IActionResult Index()
		=> View();

	[HttpPost]
	public async Task<IActionResult> Index(Contact contact)
	{
		contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
		contact.Status = true;
		await contactService.AddAsync(contact);
		return RedirectToAction("Index", "Blog");
	}
}
