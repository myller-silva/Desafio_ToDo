using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Infra.Context;
using Todo.Infra.Interfaces;

namespace Todo.Infra.Repositories;

public class AssignmentListRepository:BaseRepository<AssignmentList>, IAssignmentListRepository
{
    private readonly TodoDbContext _context;

    public AssignmentListRepository(TodoDbContext context) : base(context)
    {
        _context = context;
    }


    public virtual async Task<AssignmentList> Get(long userId, long assignmentListId)
    {
        var assignmentList = await _context.AssignmentLists
            .AsNoTracking()
            .Where(x => x.Id == assignmentListId && x.UserId == userId)
            .ToListAsync();
        return assignmentList.FirstOrDefault();
    }

    public virtual async Task Remove(long userId, long assignmentListId) //??
    {
        var assignments = await _context.Assignments
            .Where(x =>
                x.UserId == userId && x.Id == assignmentListId)
            .AsNoTracking()
            .ToListAsync();

        var assignment = assignments.FirstOrDefault();
        if (assignment != null) assignments.Remove(assignment);
        _context.SaveChangesAsync(); 
    }
}