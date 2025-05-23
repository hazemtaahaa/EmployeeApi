﻿using Employee.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Employee.BL;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;

    private readonly DbSet<T> _dbSet;
    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }


    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
      return  await _dbSet.Where(predicate).ToListAsync();    
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
       return  await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
             return  await _dbSet.FindAsync(id);
    }

    public  void Remove(T entity)
    {
          _dbSet.Remove(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
