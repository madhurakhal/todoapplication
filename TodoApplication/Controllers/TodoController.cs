using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApplication.Queries;

namespace TodoApplication.Controllers
{
    public class TodoController: BaseController
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _mediator.Send(new GetAllTodos.Query());
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(long id)
        {
            var todo = await _mediator.Send(new GetTodoById.Query(id));
            if (todo is null)
            {
                return NotFound();
            }
            return Ok(todo);
        }
    }
}