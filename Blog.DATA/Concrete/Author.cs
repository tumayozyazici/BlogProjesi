using Blog.DATA.Abstract;
using Blog.DATA.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Concrete
{
    public class Author : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Photo { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Status Status { get; set; } = Status.Added;


        //Navigations
        public List<Article> Articles { get; set; }
    }
}