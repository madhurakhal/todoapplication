using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TodoApplication.Data;
using TodoApplication.Dtos;
using TodoApplication.Services;

namespace TodoApplication.Commands
{
    public static class UpdateTodoCommand
    {
        public record Command(
            long Id,
            string? Title,
            string? Description,
            bool? Status,
            DateTime? Deadline
        ) : IRequest<TodoDto>;
        
        
        // Handeler
        public class Handeler: IRequestHandler<Command, TodoDto>
        {
            private readonly ITodoService _todoService;
            private readonly IMapper _mapper;

            public Handeler(ITodoService todoService, IMapper mapper)
            {
                _todoService = todoService;
                _mapper = mapper;
            }
            public async Task<TodoDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var todo =  _todoService.GetTodoById(request.Id);

                if (todo is null)
                {
                    return null;
                }

                if (request.Deadline is not null)
                {
                    todo.Deadline = (DateTime) request.Deadline;
                }

                if (request.Description is not null)
                {
                    todo.Description = request.Description;
                }
                
                if (request.Title is not null)
                {
                    todo.Title = request.Title;
                }

                if (request.Status.HasValue)
                {
                    todo.Status = (bool) request.Status;
                }

                var update = _todoService.Update(todo);

                return _mapper.Map<Todo, TodoDto>(todo);
                
            }
        }
        
        
    }
}