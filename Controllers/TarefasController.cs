using API_Tarefas.Database;
using API_Tarefas.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace API_Tarefas.Controllers
{
    [ApiController]
    [Route("/tarefas")]
    public class TarefasController : ControllerBase
    {
        public TarefasController(TarefasContext db) 
        {
            _db = db;
        }

        private TarefasContext _db;

        [HttpGet]
        public IActionResult Index()
        {
            var tarefas = _db.Tarefas.ToList();
            return StatusCode(200, tarefas);
        }
    }
}