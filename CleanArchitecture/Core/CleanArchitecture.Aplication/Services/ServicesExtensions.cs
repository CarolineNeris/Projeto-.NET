using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;

namespace CleanArchitecture.Application.Services;
public static class ServiceExtensions {
     public static void ConfigureApplicationApp(this IServiceCollection services) {
         services.AddAutoMapper(Assembly.GetExecutingAssembly());
         services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
         services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
     }   
}
