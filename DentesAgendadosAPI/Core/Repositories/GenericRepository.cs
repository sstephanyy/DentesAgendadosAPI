using DentesAgendadosAPI.Core.IRepositories;
using DentesAgendadosAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DentesAgendadosAPI.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DataContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger; //allows the repository to log information about database operations, such as errors or successful retrievals

        public GenericRepository(
            DataContext context,
            ILogger logger
        )
        {
            _context = context;
            _logger = logger;
            this.dbSet = _context.Set<T>();
        }
        // virtual means that this method can be overriden by a class that inherits from this class
        public virtual async Task<IEnumerable<T>> PegarTodos()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T?> PegarPorId(int id)
        {
            try
            {
                return await dbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao obter entidade com id {Id}", id);
                return null;
            }
        }

        public virtual async Task<bool> Adicionar(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao adicionar entidade");
                return false;
            }
        }

        public virtual async Task<bool> Atualizar(T entity)
        {
            try
            {
                dbSet.Update(entity);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao atualizar entidade");
                return false;
            }
        }

        public virtual async Task<bool> Deletar(int id)
        {
            try
            {
                var entity = await dbSet.FindAsync(id);
                if (entity != null)
                {
                    dbSet.Remove(entity);
                    return true;
                }
                else
                {
                    _logger.LogWarning("Entidade com id {Id} não foi achada.", id);
                    return false;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error ao deletar entidade com o id {Id}", id);
                return false;
            }
        }


    }
}
