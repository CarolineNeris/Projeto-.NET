namespace Domain.Exceptions 
{
    public class PacienteNotFoundException : Exception
    {
        public PacienteNotFoundException() : base("Paciente não encontrado.") {}
    }
}
