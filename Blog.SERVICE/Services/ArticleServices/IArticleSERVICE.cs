using Blog.DATA.Concrete;
using Blog.REPO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.SERVICE.Services.ArticleServices
{
    public interface IArticleSERVICE
    {
        int Add(Article entity);
        int Update(Article entity);
        int Delete(Article entity);

        List<ArticleListDTO> GetArticleJoinedList();
        ArticleListDTO GetArticleJoined(int articleId);
        int GetArticleCountByAuthorId(string Authorid);

        Task<List<Article>> GetAllAsync();
        Task<Article> GetByIdAsync(int id);

        Task<List<Article>> GetWhereAsync(Expression<Func<Article, bool>> expression);
    }
}
