using System;

namespace TodoApplication.Dtos
{
    public record TodoDto
    {
        public long Id { get; set; }
        public string Title { get; init; }
        public bool Status { get; init; }
        public string Description { get; init; }
        public DateTime Deadline { get; init; }
    }
}