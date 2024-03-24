using Blog.DATA.Abstract;
using Blog.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Concrete
{
    public class Article : BaseEntity
    {
        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int?  ReadingTime {  get; set; }


        //Navigations
        public string AuthorId { get; set; }

        public Author Author { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }
    }
}