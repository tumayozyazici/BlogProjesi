using Blog.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Abstract
{
    public abstract class BaseEntity
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Status Status { get; set; } = Status.Added;
    }
}
