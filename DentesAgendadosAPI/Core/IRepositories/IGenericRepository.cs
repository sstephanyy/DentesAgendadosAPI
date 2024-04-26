namespace DentesAgendadosAPI.Core.IRepositories
{
    //This interface will be used by all the repositories. It will have the basic CRUD operations that will be implemented by the repositories. It will be generic so that it can be used by all the repositories.
    // Using generics, you can define a single generic interface and implementation for all entities
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> PegarTodos();
        Task<T?> PegarPorId(int id);
        Task<bool> Adicionar(T entity);
        Task<bool> Atualizar(T entity);
        Task<bool> Deletar(int id);
    }
}
