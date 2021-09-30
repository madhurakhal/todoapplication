using System;

namespace TodoApplication.Dtos
{
    public class UpdateTodoDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public DateTime? Deadline { get; set; }
    }
}