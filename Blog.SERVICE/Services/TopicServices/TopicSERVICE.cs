using Blog.DATA.Concrete;
using Blog.DATA.Enums;
using Blog.REPO.Interfaces;
using Blog.SERVICE.Services.ArticleServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.SERVICE.Services.TopicServices
{
    public class TopicSERVICE : ITopicSERVICE
    {
        private readonly ITopicREPO topicREPO;

        public TopicSERVICE(ITopicREPO topicREPO)
        {
            this.topicREPO = topicREPO;
        }

        public int Add(Topic entity)
        {
            entity.Status = Status.Added;
            return topicREPO.Create(entity);
        }

        public int Delete(Topic entity)
        {
            entity.DeleteDate = DateTime.Now;
            entity.Status = Status.Deleted;
            return topicREPO.Update(entity);
        }

        public async Task<List<Topic>> GetAllAsync()
        {
            return await topicREPO.GetAllAsync();
        }

        public async Task<Topic> GetByIdAsync(int id)
        {
            return await topicREPO.GetByIdAsync(id);
        }

        public async Task<List<Topic>> GetWhereAsync(Expression<Func<Topic, bool>> expression)
        {
            return await topicREPO.GetWhereAsync(expression);
        }

        public int Update(Topic entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.Status = Status.Modified;
            return topicREPO.Update(entity);
        }
    }
}
