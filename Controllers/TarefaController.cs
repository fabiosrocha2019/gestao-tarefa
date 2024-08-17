using gestao_tarefa.Negocios;
using gestao_tarefa.Dados;
using Microsoft.AspNetCore.Mvc;

namespace gestao_tarefa.Controllers
{
    /// <summary>
    /// Controlador para gerenciar as tarefas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly Negocios.Interfaces.ITarefaService _tarefaService;

        /// <summary>
        /// Inicializa uma nova instância do controlador de tarefas.
        /// </summary>
        /// <param name="tarefaService">Serviço para gerenciar tarefas.</param>
        public TaskController(Negocios.Interfaces.ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        /// <summary>
        /// Obtém todas as tarefas.
        /// </summary>
        /// <returns>Uma lista de tarefas.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaDto>>> GetTasks()
        {
            var tarefas = await _tarefaService.GetAllTasksAsync();
            var tarefaDtos = tarefas.Select(t => new TarefaDto
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descricao = t.Descricao,
                DataVencimento = t.DataVencimento,
                Status = t.Status
            }).ToList();
            return Ok(tarefaDtos);
        }

        /// <summary>
        /// Obtém uma tarefa pelo ID.
        /// </summary>
        /// <param name="id">O ID da tarefa.</param>
        /// <returns>A tarefa com o ID especificado.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaDto>> GetTask(int id)
        {
            var tarefa = await _tarefaService.GetTaskByIdAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            var tarefaDto = new TarefaDto
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                DataVencimento = tarefa.DataVencimento,
                Status = tarefa.Status
            };

            return Ok(tarefaDto);
        }

        /// <summary>
        /// Adiciona uma nova tarefa.
        /// </summary>
        /// <param name="tarefaDto">Os dados da nova tarefa.</param>
        /// <returns>O status da criação da tarefa.</returns>
        [HttpPost]
        public async Task<ActionResult<TarefaDto>> AddTask(TarefaDto tarefaDto)
        {
            var tarefa = new Tarefa
            {
                Titulo = tarefaDto.Titulo,
                Descricao = tarefaDto.Descricao,
                DataVencimento = tarefaDto.DataVencimento,
                Status = tarefaDto.Status
            };

            var createdTarefa = await _tarefaService.AddTaskAsync(tarefa);

            var createdTarefaDto = new TarefaDto
            {
                Id = createdTarefa.Id,
                Titulo = createdTarefa.Titulo,
                Descricao = createdTarefa.Descricao,
                DataVencimento = createdTarefa.DataVencimento,
                Status = createdTarefa.Status
            };

            return CreatedAtAction(nameof(GetTask), new { id = createdTarefaDto.Id }, createdTarefaDto);
        }

        /// <summary>
        /// Atualiza uma tarefa existente.
        /// </summary>
        /// <param name="id">O ID da tarefa a ser atualizada.</param>
        /// <param name="tarefaDto">Os dados atualizados da tarefa.</param>
        /// <returns>O status da atualização da tarefa.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TarefaDto tarefaDto)
        {
            if (id != tarefaDto.Id)
            {
                return BadRequest();
            }

            var tarefa = new Tarefa
            {
                Id = tarefaDto.Id,
                Titulo = tarefaDto.Titulo,
                Descricao = tarefaDto.Descricao,
                DataVencimento = tarefaDto.DataVencimento,
                Status = tarefaDto.Status
            };

            var updatedTarefa = await _tarefaService.UpdateTaskAsync(tarefa);

            if (updatedTarefa == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Remove uma tarefa pelo ID.
        /// </summary>
        /// <param name="id">O ID da tarefa a ser removida.</param>
        /// <returns>O status da remoção da tarefa.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deletedTarefa = await _tarefaService.DeleteTaskAsync(id);

            if (!deletedTarefa)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}