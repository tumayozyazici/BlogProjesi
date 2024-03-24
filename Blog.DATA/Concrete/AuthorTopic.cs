using Blog.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Concrete
{
    public class AuthorTopic : BaseEntity
    {
        public int AuthorTopicId { get; set; }
        public string AuthorId { get; set; }
        public int TopicId { get; set; }


        public Topic Topic { get; set; }
        public Author Author { get; set; }
    }
}
