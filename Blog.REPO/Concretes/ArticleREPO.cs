using Blog.DATA.Concrete;
using Blog.REPO.Context;
using Blog.REPO.DTO;
using Blog.REPO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.REPO.Concretes
{
    public class ArticleREPO : BaseREPO<Article>, IArticleREPO
    {
        private readonly BlogContext _context;

        public ArticleREPO(BlogContext context) : base(context)
        {
            _context= context;
        }


        public int GetArticleCountByAuthorId(string Authorid)
        {
            return _context.Articles.Where(x => x.AuthorId == Authorid).ToList().Count;
        }

        public ArticleListDTO GetArticleJoined(int articleId)
        {
            return _context.Articles.Join(_context.Authors, a => a.AuthorId, b => b.Id, (a, b) => new { Articles = a, Authors = b }).Where(x=>x.Articles.ArticleId==articleId).Select(x => new ArticleListDTO
            {
                AuthorId = x.Authors.Id,
                ArticleId = x.Articles.ArticleId,
                Title = x.Articles.Title,
                Content = x.Articles.Content,
                ReadingTime = (int)x.Articles.ReadingTime,
                Photo = x.Authors.Photo,
                UserName = x.Authors.UserName,
                CreatedDate = x.Articles.CreateDate,
                AuthorCreatedDate = x.Authors.CreateDate

            }).FirstOrDefault();
        }

        public List<ArticleListDTO> GetArticleJoinedByInterest(List<int> topicIds)
        {
            return _context.Articles.Join(_context.Topics, a => a.TopicId, t => t.TopicId, (a, t) => new { Articles = a, Topics = t }).Join(_context.AuthorTopics, at => at.Topics.TopicId, b => b.TopicId, (at, b) => new { ArticlesTopics = at, AuthorTopics = b }).Join(_context.Authors, atb => atb.AuthorTopics.AuthorId, c => c.Id, (atb, c) => new { Combined = atb, Authors = c }).Where(x => topicIds.Contains(x.Combined.ArticlesTopics.Topics.TopicId)).Select(x=> new ArticleListDTO
            {
                AuthorId = x.Authors.Id,
                ArticleId = x.Combined.ArticlesTopics.Articles.ArticleId,
                Title = x.Combined.ArticlesTopics.Articles.Title,
                Content = x.Combined.ArticlesTopics.Articles.Content,
                ReadingTime = (int)x.Combined.ArticlesTopics.Articles.ReadingTime,
                Photo = x.Authors.Photo,
                UserName = x.Authors.UserName,
                CreatedDate = x.Combined.ArticlesTopics.Articles.CreateDate,
                AuthorCreatedDate = x.Authors.CreateDate
            }).ToList();
        }

        public List<ArticleListDTO> GetArticleJoinedByTopicId(int topicId)
        {
            return _context.Articles.Join(_context.Authors, a => a.AuthorId, b => b.Id, (a, b) => new { Articles = a, Authors = b }).Where(x => x.Articles.TopicId == topicId).Select(x => new ArticleListDTO
            {
                AuthorId = x.Authors.Id,
                ArticleId = x.Articles.ArticleId,
                Title = x.Articles.Title,
                Content = x.Articles.Content,
                ReadingTime = (int)x.Articles.ReadingTime,
                Photo = x.Authors.Photo,
                UserName = x.Authors.UserName,
                CreatedDate = x.Articles.CreateDate,
                AuthorCreatedDate = x.Authors.CreateDate

            }).ToList() ;
        }

        public List<ArticleListDTO> GetArticleJoinedList()
        {
            return _context.Articles.Join(_context.Authors, a => a.AuthorId, b => b.Id, (a, b) => new { Articles = a, Authors = b }).Select(x => new ArticleListDTO
            {
                ArticleId = x.Articles.ArticleId,
                Title = x.Articles.Title,
                Content = x.Articles.Content,
                ReadingTime = (int)x.Articles.ReadingTime,
                Photo = x.Authors.Photo,
                UserName=x.Authors.UserName,
                CreatedDate = x.Articles.CreateDate,
                AuthorCreatedDate= x.Authors.CreateDate
            }).ToList();
        }
    }
}
