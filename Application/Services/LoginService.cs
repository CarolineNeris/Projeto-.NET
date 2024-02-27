using Application.InputModels;
using Application.Interfaces;
using Application.ViewModels;
using Infrastructure;
using Infrastructure.Auth;
using Microsoft.EntityFrameworkCore;

namespace TechMed.Application.Services;
public class LoginService : ILoginService
{
   private readonly IAuthService _authService;
   private readonly ResTICDbContext _context;
    public LoginService(ResTICDbContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }
   public async Task<LoginViewModel?> AuthenticateAsync(LoginInputModel login)
   {
      string _token = "";
      var user = await _context.Usuarios.SingleOrDefaultAsync(u => u.Email == login.Username);
      if (user == null)
        {
            return null;
        }
      var _passHashed = _authService.ComputeSha256Hash(login.Password);
        if (user.Senha != _passHashed)
        {
             return null;
        }

     _token = _authService.GenerateJwtToken(login.Username, "Admin");
      
       if (_token != ""){
         return new LoginViewModel
         {
            Username = login.Username,
            Token = _token
         };
      } 

      return null;

   }
}