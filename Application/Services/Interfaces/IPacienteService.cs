using Application.InputModels;
using Application.ViewModels;

namespace Application.Services.Interfaces;

public interface IPacienteService
{
    public List<PacienteViewModel> GetAll();
    public PacienteViewModel? GetById(int id);
    public int Create(NewPacienteInputModel medico);
    public void Update(int id, NewPacienteInputModel medico);
    public void Delete(int id);
}
