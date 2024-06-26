using Blog.DATA.Abstract;
using Blog.DATA.Enums;
using Blog.REPO.Context;
using Blog.REPO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.REPO.Concretes
{
    public class BaseREPO<T> : IBaseREPO<T> where T : BaseEntity
    {
        private readonly BlogContext _context;
        private DbSet<T> _table;

        public BaseREPO(BlogContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }

        public int Create(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {
            _table.Remove(entity);
            return _context.SaveChanges();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public int Update(T entity)
        {
            _table.Update(entity);
            return _context.SaveChanges();
        }
    }
}
