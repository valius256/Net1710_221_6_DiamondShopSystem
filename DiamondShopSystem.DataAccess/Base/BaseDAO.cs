﻿using DiamondShopSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShopSystem.DataAccess.Base
{
    public class BaseDAO<T> where T : class
    {
        protected readonly Net1710_221_6_DiamondShopSystemContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseDAO()
        {
            _context = new Net1710_221_6_DiamondShopSystemContext(new DbContextOptions<Net1710_221_6_DiamondShopSystemContext>());
            _dbSet = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public async Task<int> CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public bool Remove(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T? GetById(string code)
        {
            return _dbSet.Find(code);
        }

        public async Task<T?> GetByIdAsync(string code)
        {
            return await _dbSet.FindAsync(code);
        }
    }
}
