using System.Collections.Generic;
using TodoApplication.Data;

namespace TodoApplication.Services
{
    public interface ITodoService
    {
        List<Todo> GetTodos();

        Todo GetTodoById(long id);
        int Create(Todo todo);
        int Update(Todo todo);
        void Delete(long requestId);
    }
}