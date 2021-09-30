using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoApplication.Services;

namespace TodoApplication.Controllers
{
    public class DeleteCommand
    {
        // command
        public record Command(long id) : IRequest<long>;
        
        // handeler
        public class Handeler: IRequestHandler<Command, long>
        {
            private readonly ITodoService _todoService;

            public Handeler(ITodoService todoService)
            {
                _todoService = todoService;
            }
            public async Task<long> Handle(Command request, CancellationToken cancellationToken)
            {
                _todoService.Delete(request.id);
                return request.id;
            }
        }
    }
}