using ExamProgram.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExamProgram.Core.Repositories;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
{
    public DbSet<TEntity> Table { get; }

    IQueryable<TEntity> GetAll(params string[]? includes);
    IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>>? expression, params string[]? includes);
    Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>>? expression, params string[]? includes);
    Task CreateAsync(TEntity entity);
    void Delete(TEntity entity);

    Task<int> CommitAsync();
}
