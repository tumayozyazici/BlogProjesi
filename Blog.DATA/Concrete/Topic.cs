using Blog.DATA.Abstract;
using Blog.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Concrete
{
    public class Topic : BaseEntity
    {
        public int TopicId { get; set; }

        public string TopicName { get; set; }


        //Navigations
        public List<Article> Articles { get; set; }
    }
}