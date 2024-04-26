using System.Threading.Channels;

namespace DentesAgendadosAPI.Core.IRepositories
{
    //The Unit of Work ensures all your data changes are treated as a single unit.
    //It guarantees either all changes are applied(committed) or none are(rolled back), maintaining data consistency.
    public interface IUnitOfWork
    {
        IAgendamentoRepository Agendamentos { get; }

        Task CompleteAsync(); // this method will save all the changes made to the database

    }
}
