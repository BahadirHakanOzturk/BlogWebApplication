using Blog.Entities.Concrete;

namespace Blog.Application.Contracts.Services;

public interface INewsLetterService
{
    Task AddAsync(NewsLetter newsLetter);
}
