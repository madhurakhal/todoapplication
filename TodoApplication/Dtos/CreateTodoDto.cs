using System;

namespace TodoApplication.Dtos
{
    public class CreateTodoDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}