using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TodoApplication.Data;
using TodoApplication.Dtos;
using TodoApplication.Services;

namespace TodoApplication.Queries
{
    public static class GetAllTodos
    {
        // query
        public record Query : IRequest<List<TodoDto>>;
        // handle
        
        public class Handler: IRequestHandler<Query, List<TodoDto>>
        {
            private readonly ITodoService _service;
            private readonly IMapper _mapper;

            public Handler(ITodoService service, IMapper mapper)
            {
                _service = service;
                _mapper = mapper;
            }
            public async Task<List<TodoDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var todos =  _service.GetTodos();
                return _mapper.Map<List<Todo>, List<TodoDto>>(todos);
            }
        }
        
    }
}