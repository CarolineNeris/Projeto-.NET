using Application.InputModels;
using Application.ViewModels;

namespace Application.Interfaces;
public interface ILoginService
{
   Task<LoginViewModel?> AuthenticateAsync(LoginInputModel login);
}