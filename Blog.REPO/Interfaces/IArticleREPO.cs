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
        int GetArticleCountByAuthorId(string Authorid);

        List<ArticleListDTO> GetArticleJoinedByTopicId(int topicId);
        List<ArticleListDTO> GetArticleJoinedByInterest(List<int> topicIds);

    }
}
