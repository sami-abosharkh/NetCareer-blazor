using Microsoft.EntityFrameworkCore;
using NetCareer.Data;
using NetCareer.Repository.Interface;
using System.Linq.Expressions;

namespace NetCareer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public Repository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task CreateAsync(T entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, object>>? orderBy = null, bool ascending = true, Expression<Func<T, bool>>? filter = null, string? includeProperties = null, int pageSize = 0, int pageNumber = 1)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                IQueryable<T> query = context.Set<T>();

                if (orderBy != null)
                {
                    // Apply ordering based on the specified criteria
                    query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);
                }
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                if (pageSize > 0)
                {
                    if (pageSize > 100)
                    {
                        pageSize = 100;
                    }
                    query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
                }
                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProp in includeProperties
                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return await query.ToListAsync();
            }
        }

        public async Task<T?> GetAsync(Expression<Func<T, object>>? orderBy = null, bool ascending = true, Expression<Func<T, bool>>? filter = null, bool tracked = true, string? includeProperties = null)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                IQueryable<T> query = tracked ? context.Set<T>() : context.Set<T>().AsNoTracking();

                if (orderBy != null)
                {
                    query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);
                }
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProp in includeProperties
                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return await query.FirstOrDefaultAsync();
            }
        }

        public async Task<int> GetTotalCountAsync(Expression<Func<T, bool>>? filter = null)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                IQueryable<T> query = context.Set<T>();
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                return await query.CountAsync();
            }
        }

        public async Task RemoveAsync(T entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveRange(IEnumerable<T> entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Set<T>().RemoveRange(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
