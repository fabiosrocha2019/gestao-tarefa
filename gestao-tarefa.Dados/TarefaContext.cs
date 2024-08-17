using gestao_tarefa.Negocios;
using Microsoft.EntityFrameworkCore;

namespace gestao_tarefa.Dados
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> opts)
            : base(opts)
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
