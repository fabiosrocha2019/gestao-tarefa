using gestao_tarefa.Negocios.Interfaces;
using gestao_tarefa.Dados;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace gestao_tarefa.Negocios
{
    public class TarefaService : ITarefaService
    {
        private readonly TarefaContext _context;
        private readonly IMapper _mapper;

        public TarefaService(TarefaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TarefaDto>> GetAllTasksAsync()
        {
            try
            {
                var tarefas = await _context.Tarefas.ToListAsync();
                return _mapper.Map<IEnumerable<TarefaDto>>(tarefas);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving tasks.", ex);
            }
        }

        public async Task<TarefaDto> GetTaskByIdAsync(int id)
        {
            try
            {
                var tarefa = await _context.Tarefas.FindAsync(id);
                if (tarefa == null)
                {
                    return null;
                }
                return _mapper.Map<TarefaDto>(tarefa);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while retrieving the task with ID {id}.", ex);
            }
        }

        public async Task<TarefaDto> AddTaskAsync(Tarefa tarefaDTO)
        {
            try
            {
                var tarefa = _mapper.Map<Tarefa>(tarefaDTO);
                _context.Tarefas.Add(tarefa);
                await _context.SaveChangesAsync();
                return _mapper.Map<TarefaDto>(tarefa);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the new task.", ex);
            }
        }

        public async Task<TarefaDto> UpdateTaskAsync(Tarefa tarefa)
        {
            try
            {
                //var tarefa = _mapper.Map<Tarefa>(tarefa);
                _context.Tarefas.Update(tarefa);
                await _context.SaveChangesAsync();
                return _mapper.Map<TarefaDto>(tarefa);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while updating the task with ID {tarefa.Id}.", ex);
            }
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            try
            {
                var tarefa = await _context.Tarefas.FindAsync(id);
                if (tarefa == null)
                {
                    return false;
                }
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while deleting the task with ID {id}.", ex);
            }
        }
    }
}
