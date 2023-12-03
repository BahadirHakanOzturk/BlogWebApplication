using Blog.Application.Contracts.Services;
using Blog.Application.Services;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ReportController : Controller
{
	private readonly IBlogService blogService;
	public ReportController(IBlogService blogService)
		=> this.blogService = blogService;

    public IActionResult BlogsExcel()
        => View();

    public async Task<IActionResult> ExportExcel()
	{
		using (var workbook = new XLWorkbook())
		{
			var worksheet = workbook.Worksheets.Add("Blog Listesi");
			worksheet.Cell(1, 1).Value = "Blog Id";
			worksheet.Cell(1, 2).Value = "Blog Adı";
			worksheet.Cell(1, 3).Value = "Blog İçeriği";
			int blogRowCount = 2;

			foreach (var item in await blogService.GetAllAsync())
			{
				worksheet.Cell(blogRowCount, 1).Value = item.Id;
				worksheet.Cell(blogRowCount, 2).Value = item.Title;
				worksheet.Cell(blogRowCount, 3).Value = item.Content;
				blogRowCount++;
			}

			using (var stream = new MemoryStream())
			{
				workbook.SaveAs(stream);
				var content = stream.ToArray();
				return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Bloglar.xlsx");
			}
		}
	}
}
