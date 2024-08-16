using gestao_tarefa.Negocios;
using Microsoft.AspNetCore.Mvc;

namespace gestao_tarefa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly Negocios.Interfaces.ITarefaService _tarefaService;

        public TaskController(Negocios.Interfaces.ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        // GET: api/Task
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

        // GET: api/Task/{id}
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

        // POST: api/Task
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

        // PUT: api/Task/{id}
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

        // DELETE: api/Task/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deletedTarefa = await _tarefaService.DeleteTaskAsync(id);

            if (deletedTarefa == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}