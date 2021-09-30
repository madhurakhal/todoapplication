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

        public int Create(Todo todo)
        {
             _context.Todos.Add(todo);
            return _context.SaveChanges();
        }

        public int Update(Todo todo)
        {
            _context.Attach(todo);
            return _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var todo = _context.Todos.FirstOrDefault(todo => todo.Id == id);

            if (todo is null)
            {
                return;
            }
            _context.Todos.Remove(todo);
            _context.SaveChanges();
        }
    }
}