using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Infra.Context;
using Todo.Infra.Interfaces;

namespace Todo.Infra.Repositories;

public class AssignmentRepository: BaseRepository<Assignment>, IAssignmentRepository
{
    private readonly TodoDbContext _context;

    public AssignmentRepository(TodoDbContext context) : base(context)
    {
        _context = context;
    }

    public virtual async Task<List<Assignment>> GetAll(long userId)
    {
        var assignments = await _context.Assignments
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .ToListAsync();
        return assignments;
    } 

    public virtual async Task<List<Assignment>> SearchByDescription(string description)
    {
        var descriptions = await _context.Assignments
            .Where(x => x.Description.ToLower().Contains(description.ToLower()))
            .AsNoTracking()
            .ToListAsync();
        return descriptions;
    }

    public virtual async Task Remove(long userId, long assignmentId) //???
    {
        var assignments = await _context.Assignments
            .Where(x =>
                x.UserId == userId && x.Id == assignmentId)
            .AsNoTracking()
            .ToListAsync();

        var assignment = assignments.FirstOrDefault();
        if (assignment != null) assignments.Remove(assignment);
        
        await _context.SaveChangesAsync();
    }
    
    
    // public override async Task<Assignment> Create(Assignment assignment)
    // {
    //     _context.Assignments.Add(assignment);
    //     await _context.SaveChangesAsync();
    //     return assignment;
    // }
}