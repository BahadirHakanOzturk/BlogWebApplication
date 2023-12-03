using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ViewModels;

public class RoleVM
{
	[Required(ErrorMessage = "Lütfen rol adı giriniz")]
	public string Name { get; set; }
}
