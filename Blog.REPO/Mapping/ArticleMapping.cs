using Blog.DATA.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.REPO.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasOne(x=>x.Author).WithMany(x=>x.Articles).HasForeignKey(x=>x.AuthorId);
            builder.HasOne(x => x.Topic).WithMany(y => y.Articles).HasForeignKey(x => x.TopicId);
        }
    }
}
