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
    public class TopicREPO : BaseREPO<Topic>, ITopicREPO
    {
        private readonly BlogContext _context;

        public TopicREPO(BlogContext context) : base(context)
        {
            _context = context;
        }
    }
}
