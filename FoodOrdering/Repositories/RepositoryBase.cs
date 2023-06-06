using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public class RepositoryBase
{
    protected readonly MyDbContext _context;

    protected RepositoryBase(MyDbContext context)
    {
        _context = context;
    }
    
    public void Save() => _context.SaveChanges();
}