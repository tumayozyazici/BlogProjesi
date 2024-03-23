using Blog.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.SERVICE.Services.TopicServices
{
    public interface ITopicSERVICE
    {
        int Add(Topic entity);
        int Update(Topic entity);
        int Delete(Topic entity);

        Task<List<Topic>> GetAllAsync();
        Task<Topic> GetByIdAsync(int id);

        Task<List<Topic>> GetWhereAsync(Expression<Func<Topic, bool>> expression);
    }
}
