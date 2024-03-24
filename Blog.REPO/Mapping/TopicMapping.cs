using Blog.DATA.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.REPO.Mapping
{
    public class TopicMapping : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasData(new Topic { TopicId = 1, TopicName = "Bilimsel" });
            builder.HasData(new Topic { TopicId = 2, TopicName = "Tarihsel" });
            builder.HasData(new Topic { TopicId = 3, TopicName = "Finansal" });
            builder.HasData(new Topic { TopicId = 4, TopicName = "Evrimsel" });
            builder.HasData(new Topic { TopicId = 5, TopicName = "Siyasal" });

            builder.HasMany(x=>x.AuthorTopics).WithOne(x=>x.Topic).HasForeignKey(x=>x.TopicId);
        }
    }
}
