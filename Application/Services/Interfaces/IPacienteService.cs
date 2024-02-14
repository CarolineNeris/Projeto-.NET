using Application.InputModels;
using Application.ViewModels;

namespace Application.Services.Interfaces;

public interface IPacienteService
{
    public List<PacienteViewModel> GetAll();
    public PacienteViewModel? GetById(int id);
    public int Create(NewPacienteInputModel paciente);
    public void Update(int id, NewPacienteInputModel paciente);
    public void Delete(int id);
}
