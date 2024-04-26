using DentesAgendadosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DentesAgendadosAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
