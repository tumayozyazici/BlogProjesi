using Blog.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.REPO.Interfaces
{
    public interface IAuthorTopicREPO : IBaseREPO<AuthorTopic>
    {
        int Create(IEnumerable<AuthorTopic> entities);
        int Update(IEnumerable<AuthorTopic> entities);
        int Delete(IEnumerable<AuthorTopic> entities);

        IEnumerable<AuthorTopic> GetByAuthorId(string id);

    }
}
