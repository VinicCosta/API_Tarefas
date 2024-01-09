using API_Tarefas.Database;
using API_Tarefas.DTO;
using API_Tarefas.Models;
using API_Tarefas.Models.Error;

namespace API_Tarefas.Services.Interfaces
{
    public interface ITarefaServices
    {
        List<Tarefa> List();

        Tarefa Include(TarefaDto tarefaDto);

        Tarefa Update(int id, TarefaDto tarefaDto);

        Tarefa SearchId(int id);

        void Delete(int id);
    }
}