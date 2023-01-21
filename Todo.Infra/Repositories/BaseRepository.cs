using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Infra.Context;
using Todo.Infra.Interfaces;

namespace Todo.Infra.Repositories;

public class BaseRepository<T>:IBaseRepository<T> where T: Base
{
    private readonly TodoDbContext _context;

    public BaseRepository(TodoDbContext context)
    {
        _context = context;
    }
    
    public virtual async Task<T> Create(T obj)
    {
        // _context.Set<T>().Add(obj);
        _context.Add(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task<T> Get(long id)
    {
        var obj = await _context.Set<T>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ToListAsync();
        return obj.FirstOrDefault();
    }

    public virtual async Task<List<T>> Get()
    {
        var obj = await _context.Set<T>()
            .AsNoTracking() 
            .ToListAsync();
        return obj;
    }

    public  virtual async Task<T> Update(T obj)
    {
        // _context.Update(obj);
        _context.Entry(obj).State = EntityState.Modified; // pesquisar mais sobre
        await _context.SaveChangesAsync();
        return obj;
    }

}