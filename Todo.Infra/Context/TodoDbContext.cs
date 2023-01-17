using Microsoft.EntityFrameworkCore;

namespace Todo.Infra.Context;

public class TodoDbContext: DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options):base(options)
    {
        
    }
}