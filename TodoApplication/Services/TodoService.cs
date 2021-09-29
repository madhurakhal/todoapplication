using System.Collections.Generic;
using System.Linq;
using TodoApplication.Data;

namespace TodoApplication.Services
{
    public class TodoService: ITodoService
    {
        private readonly TodoContext _context;

        public TodoService(TodoContext context)
        {
            _context = context;
        }
        
        public  List<Todo> GetTodos()
        {
            return  _context.Todos.ToList();
        }

        public Todo GetTodoById(long id)
        {
            return _context.Todos.FirstOrDefault(todo => todo.Id == id);
        }
    }
}