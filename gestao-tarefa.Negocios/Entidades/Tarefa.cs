using gestao_tarefa.Negocios.Enum;
using System.ComponentModel.DataAnnotations;

namespace gestao_tarefa.Negocios
{
    public class Tarefa
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        [StringLength(100)]
        public virtual string Titulo { get; set; }

        [Required]
        [StringLength(500)]
        public virtual string Descricao { get; set; }

        public virtual DateTime? DataVencimento { get; set; }

        [Required]
        public virtual StatusEnum Status { get; set; }
    }
       
}