using AutoMapper;

namespace gestao_tarefa.Dados.Mappings
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {

            CreateMap<Tarefa, TarefaDto>().ReverseMap();
        }
    }
}
