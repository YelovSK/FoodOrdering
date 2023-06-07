using System.Linq.Expressions;
using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly MyDbContext _context;

    public GenericRepository(MyDbContext context)
    {
        _context = context;
    }

    public T? SingleOrDefault(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().SingleOrDefault(expression);
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public T? FirstOrDefault(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().FirstOrDefault(expression);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }
}