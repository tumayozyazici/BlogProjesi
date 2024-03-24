using Blog.DATA.Concrete;
using Blog.DATA.Enums;
using Blog.REPO.Concretes;
using Blog.REPO.DTO;
using Blog.REPO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.SERVICE.Services.ArticleServices
{
    public class ArticleSERVICE : IArticleSERVICE
    {
        private readonly IArticleREPO articleREPO;

        public ArticleSERVICE(IArticleREPO articleREPO)
        {
            this.articleREPO = articleREPO;
        }

        public int Add(Article entity)
        {
            
            entity.Status = Status.Added;
            return articleREPO.Create(entity);
        }

        public int Delete(Article entity)
        {
            entity.DeleteDate = DateTime.Now;
            entity.Status = Status.Deleted;
            return articleREPO.Update(entity);
        }

        public async Task<List<Article>> GetAllAsync()
        {
            return await articleREPO.GetAllAsync();
        }

        public int GetArticleCountByAuthorId(string Authorid)
        {
            return articleREPO.GetArticleCountByAuthorId(Authorid);
        }

        public ArticleListDTO GetArticleJoined(int articleId)
        {
            return articleREPO.GetArticleJoined(articleId);
        }

        public List<ArticleListDTO> GetArticleJoinedList()
        {
            return articleREPO.GetArticleJoinedList();
        }

        public async Task<Article> GetByIdAsync(int id)
        {
            return await articleREPO.GetByIdAsync(id);
        }

        public async Task<List<Article>> GetWhereAsync(Expression<Func<Article, bool>> expression)
        {
            return await articleREPO.GetWhereAsync(expression);
        }

        public int Update(Article entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.Status = Status.Modified;
            return articleREPO.Update(entity);
        }
    }
}
