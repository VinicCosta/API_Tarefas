using API_Tarefas.Database;
using API_Tarefas.DTO;
using API_Tarefas.Models;
using API_Tarefas.Models.Error;
using API_Tarefas.ModelViews;
using API_Tarefas.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Tarefas.Controllers
{
    [ApiController]
    [Route("/tarefas")]
    public class TarefasController : ControllerBase
    {
        public TarefasController(TarefaServices service) 
        {
            _service = service;
        }

        private TarefaServices _service;

        [HttpGet]
        public IActionResult Index()
        {
            var tarefas = _service.List();
            return StatusCode(200, tarefas);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TarefaDto tarefaDto)
        {
            try
            {
                var tarefa = _service.Include(tarefaDto);
                return StatusCode(201, tarefa);
            }catch (TarefaError ex)
            {
                return StatusCode(400, new ErrorView { Mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody] TarefaDto tarefaDto)
        {
            try 
            { 
                var tarefaDb = _service.Update(id, tarefaDto);
                return StatusCode(201, tarefaDb);
            }
            catch (TarefaError ex)
            {
                return StatusCode(400, new ErrorView { Mensagem = ex.Message });
            }
        }


        [HttpGet("{id}")]
        public IActionResult Show([FromRoute] int id)
        {
            try
            {
                var tarefaDb = _service.SearchId(id);
                return StatusCode(201, tarefaDb);
            }catch (TarefaError ex)
            {
                return StatusCode(404, new ErrorView { Mensagem=ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _service.Delete(id);
                return StatusCode(204);
            }
            catch (TarefaError ex)
            {
                return StatusCode(400, new ErrorView { Mensagem = ex.Message });
            }

        }
    }
}