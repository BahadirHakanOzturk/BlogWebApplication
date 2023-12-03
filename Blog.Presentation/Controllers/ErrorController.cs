using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers;

[AllowAnonymous]
public class ErrorController : Controller
{
	public IActionResult Error1(int code)
		=> View();
}
