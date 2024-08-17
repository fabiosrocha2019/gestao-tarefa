using System.ComponentModel;

namespace gestao_tarefa.Negocios
{
    [Description("Status das Tarefas")]
    public enum StatusEnum
    {
        [Description("Pendente")]
        Pendente,
        [Description("Andamento")]
        Andamento,
        [Description("Concluido")]
        Concluido
    }
}
