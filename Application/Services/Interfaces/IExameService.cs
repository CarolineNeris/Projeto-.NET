using Application.InputModels;
using Application.ViewModels;

namespace Application.Services.Interfaces;
public interface IExameService
{
    public List<ExameViewModel> GetAll();
    public int Create(NewExameInputModel exame);
}
