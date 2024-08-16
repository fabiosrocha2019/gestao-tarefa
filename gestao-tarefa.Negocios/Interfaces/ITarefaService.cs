namespace gestao_tarefa.Negocios.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> GetAllTasksAsync();
        Task<Tarefa> GetTaskByIdAsync(int id);
        Task<Tarefa> AddTaskAsync(Tarefa tarefa);
        Task<Tarefa> UpdateTaskAsync(Tarefa tarefa);
        Task<Tarefa> DeleteTaskAsync(int id);
    }
}
