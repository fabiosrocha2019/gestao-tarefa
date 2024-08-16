namespace gestao_tarefa.Dados
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> GetAllTasksAsync();
        Task<Tarefa> GetTaskByIdAsync(int id);
        Task<Tarefa> AddTaskAsync(Tarefa tarefa);
        Task<Tarefa> UpdateTaskAsync(Tarefa tarefa);
        Task<Tarefa> DeleteTaskAsync(int id);
    }
}
