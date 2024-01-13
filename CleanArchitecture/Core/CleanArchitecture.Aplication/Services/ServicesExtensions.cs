using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;

namespace CleanArchitecture.Aplication.Services;
public static class ServiceExtensions {
     public static void ConfigureApplicationServices(this IServiceCollection services) {
         services.AddAutoMapper(Assembly.GetExecutingAssembly());
         services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
         services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
     }   
}
