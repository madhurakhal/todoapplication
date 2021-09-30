using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApplication.Commands;
using TodoApplication.Dtos;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoDto createTodoDto)
        {
            var id =  await  _mediator.Send(new CreateTodoCommand.Command(
                createTodoDto.Title,
                createTodoDto.Description,
                createTodoDto.Deadline
                ));
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateTodoDto updateTodoDto)
        {
            var todo =  await _mediator.Send(new UpdateTodoCommand.Command(
                id,
                updateTodoDto.Title,
                updateTodoDto.Description,
                updateTodoDto.Status,
                updateTodoDto.Deadline
            ));
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteCommand.Command(id));
            return Ok();
        }
    }
}