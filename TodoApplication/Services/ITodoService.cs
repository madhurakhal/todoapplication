using System.Collections.Generic;
using TodoApplication.Data;

namespace TodoApplication.Services
{
    public interface ITodoService
    {
        List<Todo> GetTodos();

        Todo GetTodoById(long id);
    }
}