using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoApplication.Data;
using TodoApplication.Services;

namespace TodoApplication.Commands
{
    public static class CreateTodoCommand
    {
        // command
        public record Command(
            string Title,
            string Description,
            DateTime Deadline
            ) : IRequest<int>;
        
        // handler

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly ITodoService _todoService;

            public Handler(ITodoService todoService)
            {
                _todoService = todoService;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var todo = new Todo()
                {
                    Title = request.Title,
                    Description = request.Description,
                    Deadline = request.Deadline,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                return  _todoService.Create(todo);
            }
        }
    }
}