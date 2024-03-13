using BookShop.Domain.Entities;
using System.Linq.Expressions;

namespace BookShop.Domain.Interfaces.GenericRepositories;

public interface IGenericRepository<T> where T : Auditable
{
    IQueryable<T> GetAll(Expression<Func<T, bool>> expression, string[] includes = null, bool istraking = true);
    ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, bool isTracking = true, string[] includes = null);
    ValueTask<T> CreateAsync(T entity);
    T UpdateAsync(T entity);
    ValueTask<bool> DeleteAsync(int id);
    ValueTask SaveChangesAsync();
}
