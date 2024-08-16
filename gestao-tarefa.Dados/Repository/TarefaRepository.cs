using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestao_tarefa.Dados.Repository
{
    public class TarefaRepository : Interfaces.ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> GetAllTasksAsync()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> GetTaskByIdAsync(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task<Tarefa> AddTaskAsync(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> UpdateTaskAsync(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> DeleteTaskAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return null;
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }
    }
}
