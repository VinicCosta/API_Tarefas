using API_Tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Tarefas.Database
{
    public class TarefasContext : DbContext
    {
        #nullable disable
        public TarefasContext(DbContextOptions<TarefasContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
