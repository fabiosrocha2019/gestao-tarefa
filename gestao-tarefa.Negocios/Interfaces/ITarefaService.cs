namespace gestao_tarefa.Negocios.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefaDto>> GetAllTasksAsync();
        Task<TarefaDto> GetTaskByIdAsync(int id);
        Task<TarefaDto> AddTaskAsync(Tarefa tarefa);
        Task<TarefaDto> UpdateTaskAsync(Tarefa tarefa);
        Task<bool> DeleteTaskAsync(int id);
    }
}
