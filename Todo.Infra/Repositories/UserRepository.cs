using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Infra.Context;
using Todo.Infra.Interfaces; 

namespace Todo.Infra.Repositories;

public class UserRepository: BaseRepository<User>, IUserRepository
{
    
    private readonly TodoDbContext _context;
    public UserRepository(TodoDbContext context) : base(context) //???
    {
        _context = context;
    } 

    public virtual async Task Remove(long id)
    {
        var users = await _context.Users
            .AsNoTracking()
            .Where(x=>x.Id==id)
            .ToListAsync();
        var user = users.FirstOrDefault();
        if (user != null)
        {
            // #region remover todas as tasks do usuario
            // var assignments = await  _context.Assignments
            //     .Where(x=>x.UserId==user.Id & x.AssignmentListId==null)
            //     .AsNoTracking()
            //     .ToListAsync(); 
            //
            // _context.Assignments.RemoveRange(assignments);
            // #endregion
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
    public virtual async Task<User> GetByEmail(string email)
    {
        var user = await _context.Users
            .Where(x => x.Email == email)
            .AsNoTracking()
            .ToListAsync();
        return user.FirstOrDefault();
    }

    public virtual async Task<List<User>> SearchByEmail(string email)
    {
        var users = await _context.Users
            .Where(x => x.Email.ToLower().Contains(email.ToLower()))
            .AsNoTracking()
            .ToListAsync();
        return users;
    }
    
    public async Task<List<User>> SearchByName(string name)
    {
        var users = await _context.Users
            .Where(
                x => x.Name.ToLower().Contains(name)
            )
            .AsNoTracking()
            .ToListAsync();
        return users;
    }
}