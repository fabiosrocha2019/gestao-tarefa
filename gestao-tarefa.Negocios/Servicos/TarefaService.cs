using gestao_tarefa.Negocios.Interfaces;

namespace gestao_tarefa.Negocios.Servicos
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<IEnumerable<Tarefa>> GetAllTasksAsync()
        {
            return await _tarefaRepository.GetAllTasksAsync();
        }

        public async Task<Tarefa> GetTaskByIdAsync(int id)
        {
            return await _tarefaRepository.GetTaskByIdAsync(id);
        }

        public async Task<Tarefa> AddTaskAsync(Tarefa tarefa)
        {
            return await _tarefaRepository.AddTaskAsync(tarefa);
        }

        public async Task<Tarefa> UpdateTaskAsync(Tarefa tarefa)
        {
            return await _tarefaRepository.UpdateTaskAsync(tarefa);
        }

        public async Task<Tarefa> DeleteTaskAsync(int id)
        {
            return await _tarefaRepository.DeleteTaskAsync(id);
        }
    }
}
