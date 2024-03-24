using Blog.DATA.Concrete;
using Blog.REPO.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.REPO.Interfaces
{
    public interface IArticleREPO :IBaseREPO<Article>
    {
        List<ArticleListDTO> GetArticleJoinedList();
        ArticleListDTO GetArticleJoined(int articleId);
        public int GetArticleCountByAuthorId(string Authorid);

    }
}
