using Blog.DATA.Concrete;
using Blog.REPO.Context;
using Blog.REPO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.REPO.Concretes
{
    public class AuthorTopicREPO : BaseREPO<AuthorTopic>, IAuthorTopicREPO
    {
        private readonly BlogContext _context;
        public AuthorTopicREPO(BlogContext context) : base(context)
        {
            _context = context;
        }

        public int Create(IEnumerable<AuthorTopic> entities)
        {
            _context.AuthorTopics.AddRange(entities);
            return _context.SaveChanges();
        }

        public int Delete(IEnumerable<AuthorTopic> entities)
        {
            _context.AuthorTopics.RemoveRange(entities);
            return _context.SaveChanges();
        }

        public IEnumerable<AuthorTopic> GetByAuthorId(string id)
        {
            return _context.AuthorTopics.Where(x => x.AuthorId == id).ToList();
        }

        public int Update(IEnumerable<AuthorTopic> entities)
        {
            _context.AuthorTopics.UpdateRange(entities);
            return _context.SaveChanges();
        }
    }
}
