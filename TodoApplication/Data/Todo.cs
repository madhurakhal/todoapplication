using System;

namespace TodoApplication.Data
{
    public class Todo: IEntity
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}