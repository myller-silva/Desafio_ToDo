using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Infra.Mappings;

namespace Todo.Infra.Context;

public class TodoDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<AssignmentList> AssignmentLists { get; set; }
    public TodoDbContext(DbContextOptions<TodoDbContext> options):base(options)
    {
        
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new AssignmentListMap());
        modelBuilder.ApplyConfiguration(new AssignmentMap());


        // foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany( e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
        //     property.SetColumnType("varchar(100)");
        //
        // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.ApplyConfiguration(new UserMap());
    //     // modelBuilder.ApplyConfiguration(new UserMap());
    //     // modelBuilder.ApplyConfiguration(new UserMap());
    // }
}