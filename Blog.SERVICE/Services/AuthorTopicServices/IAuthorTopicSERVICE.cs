using Blog.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.SERVICE.Services.AuthorTopicServices
{
    public interface IAuthorTopicSERVICE
    {
        int Create(IEnumerable<AuthorTopic> entities);
        int Update(IEnumerable<AuthorTopic> entities);
        int Delete(IEnumerable<AuthorTopic> entities);

        IEnumerable<AuthorTopic> GetByAuthorId(string id);

        Task<List<AuthorTopic>> GetAllAsync();
    }
}
