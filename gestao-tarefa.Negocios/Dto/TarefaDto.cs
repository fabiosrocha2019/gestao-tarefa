using System.ComponentModel.DataAnnotations;

namespace gestao_tarefa.Negocios
{
    public class TarefaDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string Descricao { get; set; }

        public DateTime? DataVencimento { get; set; }

        [Required]
        public StatusEnum Status { get; set; }
    }
}
