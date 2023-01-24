using Microsoft.EntityFrameworkCore;
using Todo.Core;
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

    private async Task<bool> ExistsAssignmentList(long? assignmentListId, long? userId)
    {
        var assignmentLists = await _context.AssignmentLists
            .Where(
                x=>x.Id == assignmentListId
                && x.UserId == userId )
            .AsNoTracking()
            .ToListAsync();
        
        if (assignmentLists.FirstOrDefault() == null) return false;
        return true;
    }
    
    public override async Task<Assignment> Create(Assignment obj) 
    {
        var assignmentListId = obj.AssignmentListId;
        if (assignmentListId == null || assignmentListId == 0)
        {
            _context.Assignments.Add(obj);
            await _context.SaveChangesAsync(); 
            return obj;
        } 
        if (!await ExistsAssignmentList(assignmentListId, obj.UserId))
            throw new DomainException("Não existe uma lista de tasks com o id informado: " + assignmentListId);
        throw new DomainException("Erro ao criar Task");
    }

    public virtual async Task<List<Assignment>> GetAll(long userId)
    {
        var assignments = await _context.Assignments
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .ToListAsync();
        return assignments;
    }

    public async Task<Assignment> Get(long userId, long id)
    {
        var assignments = await _context.Assignments
            .AsNoTracking()
            .Where(x => x.UserId == userId && id ==x.Id)
            .ToListAsync();
        return assignments.FirstOrDefault();
    }

    public virtual async Task<List<Assignment>> SearchByDescription(string description)
    {
        var descriptions = await _context.Assignments
            .Where(x => x.Description.ToLower().Contains(description.ToLower()))
            .AsNoTracking()
            .ToListAsync();
        return descriptions;
    }

    public virtual async Task Remove(long userId, long assignmentId) 
    {
        var assignments = await _context.Assignments
            .Where(x =>
                x.UserId == userId 
                && x.Id == assignmentId)
            .AsNoTracking()
            .ToListAsync();

        var assignment = assignments.FirstOrDefault();
        
        if (assignment != null) _context.Assignments.Remove(assignment);
        else throw new DomainException("Task nao encontrada");
        
        await _context.SaveChangesAsync();
    }
    
    
    // public override async Task<Assignment> Create(Assignment assignment)
    // {
    //     _context.Assignments.Add(assignment);
    //     await _context.SaveChangesAsync();
    //     return assignment;
    // }
}