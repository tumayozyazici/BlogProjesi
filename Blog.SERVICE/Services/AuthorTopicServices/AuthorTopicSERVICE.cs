using Blog.DATA.Concrete;
using Blog.REPO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.SERVICE.Services.AuthorTopicServices
{
    public class AuthorTopicSERVICE : IAuthorTopicSERVICE
    {
        private readonly IAuthorTopicREPO authorTopicREPO;

        public AuthorTopicSERVICE(IAuthorTopicREPO authorTopicREPO)
        {
            this.authorTopicREPO = authorTopicREPO;
        }

        public int Create(IEnumerable<AuthorTopic> entities)
        {
            return authorTopicREPO.Create(entities);
        }

        public int Delete(IEnumerable<AuthorTopic> entities)
        {
            return authorTopicREPO.Delete(entities);
        }

        public async Task<List<AuthorTopic>> GetAllAsync()
        {
            return await authorTopicREPO.GetAllAsync();
        }

        public IEnumerable<AuthorTopic> GetByAuthorId(string id)
        {
            return authorTopicREPO.GetByAuthorId(id);
        }

        public int Update(IEnumerable<AuthorTopic> entities)
        {
            return authorTopicREPO.Update(entities);
        }
    }
}
