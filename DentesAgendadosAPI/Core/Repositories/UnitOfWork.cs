using DentesAgendadosAPI.Core.IRepositories;
using DentesAgendadosAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DentesAgendadosAPI.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable // IDisposable is used to free unmanaged resources
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;
        public IAgendamentoRepository Agendamentos { get; private set; }

        // constructor will take the context and logger factory as parameters
        public UnitOfWork(
            DataContext context,
            ILoggerFactory loggerFactory
        )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Agendamentos = new AgendamentoRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
