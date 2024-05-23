using ExamProgram.Core.Entities;
using ExamProgram.Core.Repositories;
using ExamProgram.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExamProgram.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly DataContext _context;

    public GenericRepository(DataContext context)
    {
        _context = context;
    }
    public DbSet<TEntity> Table => _context.Set<TEntity>();

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task CreateAsync(TEntity entity)
    {
        await Table.AddAsync(entity);
    }

    public void Delete(TEntity entity)
    {
        Table.Remove(entity);
    }

    public IQueryable<TEntity> GetAll(params string[]? includes)
    {
        var query = _addIncludes(includes);

        return query;
    }

    public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>>? expression, string[]? includes)
    {
        var query = _addIncludes(includes);

        return expression is not null
                    ? await query.Where(expression).FirstOrDefaultAsync()
                    : await query.FirstOrDefaultAsync();
    }

    public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>>? expression, string[]? includes)
    {
        var query = _addIncludes(includes);

        return expression is not null
                        ? query.Where(expression)
                        : query;
    }

    private IQueryable<TEntity> _addIncludes(string[]? includes)
    {
        var query = Table.AsQueryable();

        if (includes is not null && includes.Length > 0)
        {
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
        }

        return query;
    }
}
