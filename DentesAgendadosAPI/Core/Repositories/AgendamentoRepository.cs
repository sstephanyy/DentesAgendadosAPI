using DentesAgendadosAPI.Core.IRepositories;
using DentesAgendadosAPI.Data;
using DentesAgendadosAPI.Models;

namespace DentesAgendadosAPI.Core.Repositories
{
    public class AgendamentoRepository : GenericRepository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(DataContext context, ILogger logger) : base(context, logger)
        {
        }

       
    }
}
