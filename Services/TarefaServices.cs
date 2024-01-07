using API_Tarefas.Database;
using API_Tarefas.DTO;
using API_Tarefas.Models;
using API_Tarefas.Models.Error;

namespace API_Tarefas.Services
{
    public class TarefaServices
    {
       public TarefaServices(TarefasContext db) 
        {
            _db = db;
        }

        private TarefasContext _db;

        public List<Tarefa> List()
        {
            return _db.Tarefas.ToList();
        }

        public Tarefa Include(TarefaDto tarefaDto)
        {
            if (string.IsNullOrEmpty(tarefaDto.Titulo)) throw new TarefaError("O título da tarefa não pode ser vazio.");

            var tarefa = new Tarefa
            {
                Titulo = tarefaDto.Titulo,
                Descricao = tarefaDto.Descricao,
                Concluida = tarefaDto.Concluida,
            };

            _db.Tarefas.Add(tarefa);
            _db.SaveChanges();
            return tarefa;
        }

        public Tarefa Update(int id, TarefaDto tarefaDto)
        {
            if (string.IsNullOrEmpty(tarefaDto.Titulo)) throw new TarefaError("O título da tarefa não pode ser vazio.");

            var tarefaDb = _db.Tarefas.Find(id);
            if (tarefaDb == null) throw new TarefaError("Tarefa não encontrada.");

            tarefaDb.Titulo = tarefaDto.Titulo;
            tarefaDb.Descricao = tarefaDto.Descricao;
            tarefaDb.Concluida = tarefaDto.Concluida;

            _db.Tarefas.Update(tarefaDb);
            _db.SaveChanges();
            return tarefaDb;
        }

        public Tarefa SearchId(int id)
        {
            var tarefaDb = _db.Tarefas.Find(id);
            if (tarefaDb == null) throw new TarefaError("Tarefa não encontrada.");

            return tarefaDb;
        }

        public void Delete(int id)
        {
            var tarefaDb = _db.Tarefas.Find(id);
            if (tarefaDb == null) throw new TarefaError ("Tarefa não encontrada.");

            _db.Tarefas.Remove(tarefaDb);
            _db.SaveChanges();
        }
    }
}