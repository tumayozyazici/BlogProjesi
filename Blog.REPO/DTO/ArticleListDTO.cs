using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.REPO.DTO
{
    public class ArticleListDTO
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public int ReadingTime { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string Photo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime AuthorCreatedDate { get; set; }
        public int? ArticleCount { get; set; }
        public string AuthorId { get; set; }
    }
}
