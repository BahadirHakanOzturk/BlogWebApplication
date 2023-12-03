using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Contracts.Services;

public interface INewsLetterService
{
    Task AddAsync(NewsLetter newsLetter);
}
