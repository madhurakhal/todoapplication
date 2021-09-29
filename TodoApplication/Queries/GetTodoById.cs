using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TodoApplication.Data;
using TodoApplication.Dtos;
using TodoApplication.Services;

namespace TodoApplication.Queries
{
    public static class GetTodoById
    {
        public  record Query(long id) : IRequest<TodoDto>;
        
        internal class Handler: IRequestHandler<Query, TodoDto>
        {
            private readonly ITodoService _service;
            private readonly IMapper _mapper;

            public Handler(ITodoService service, IMapper mapper)
            {
                _service = service;
                _mapper = mapper;
            }
            public  async  Task<TodoDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var todo = _service.GetTodoById(request.id);
                return todo is null ? null : _mapper.Map<Todo, TodoDto>(todo);
            }
        }
    }
}