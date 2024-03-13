using BookShop.Domain.Entities;
using BookShop.Domain.Interfaces.GenericRepositories;
using BookShop.Infrastucture.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShop.Infrastucture.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
{
    protected readonly BookShopDbContext _dbContext;
    protected readonly DbSet<T> _dbSet;
    public GenericRepository(BookShopDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }
    public async ValueTask<T> CreateAsync(T entity) 
        => (await _dbContext.AddAsync(entity)).Entity;

    /// <summary>
    /// this function for delete entity models
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async ValueTask<bool> DeleteAsync(int id)
    {
        var entity = await GetAsync(e => e.Id == id);

        if (entity is null)
            return false;

        _dbSet.Remove(entity);

        return true;
    }

    public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> expression, string[] includes = null, bool istraking = true)
    {
        var query = expression is null ? _dbSet : _dbSet.Where(expression);

        if (includes != null)
            foreach (var include in includes)
                if (!string.IsNullOrEmpty(include))
                    query = query.Include(include);

        if (!istraking)
            query = query.AsNoTracking();

        return query;
    }

    public async ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, bool isTracking = true, string[] includes = null) 
        => await GetAll(expression, includes, isTracking).FirstOrDefaultAsync();

    public async ValueTask SaveChangesAsync() 
        => await SaveChangesAsync();

    public T UpdateAsync(T entity) =>
        _dbSet.Update(entity).Entity;
}
