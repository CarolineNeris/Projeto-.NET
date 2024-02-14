namespace Domain.Exceptions
{
    public class MedicoNotFoundException : Exception
    {
        public MedicoNotFoundException() : base("Medico não encontrado") {}
    }
}
