using System;

namespace TodoApplication.Dtos
{
    public record TodoDto
    {
        public string Title { get; init; }
        public bool Status { get; init; }
        public string Description { get; init; }
        public DateTime Deadline { get; init; }
    }
}