using Blog.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.REPO.Interfaces
{
    public interface IBaseREPO<T> where T : BaseEntity
    {
        int Create(T entity);
        int Update(T entity);
        int Delete(T entity);

        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression);
    }
}
