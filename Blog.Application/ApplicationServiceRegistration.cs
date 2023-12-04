using Blog.Application.ValidationRules;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blog.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<BlogAddVMValidator>());
        services.AddSession();
        services.AddMvc(config =>  //Authorization at project level
        {
            var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
            config.Filters.Add(new AuthorizeFilter(policy));
        });
        services.AddAuthentication(  //Direct Login/Index if it is not authorized
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    }
    );
        return services;
    }
}