using Microsoft.EntityFrameworkCore;

namespace TodoApplication.Data
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> context): base(context)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite($"Data Source=todos.sqlite");

        public DbSet<Todo> Todos { get; set; }
    }
}