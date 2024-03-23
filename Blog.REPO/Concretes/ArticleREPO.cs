using Blog.DATA.Concrete;
using Blog.REPO.Context;
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
    }
}
