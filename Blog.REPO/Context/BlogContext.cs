﻿using Blog.DATA.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blog.REPO.Context
{
    public class BlogContext : IdentityDbContext<Author, AppRole, string>
    {
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<AuthorTopic> AuthorTopics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			//optionsBuilder.UseSqlServer("Server=GHOST2023\\SQLEXPRESS;Database=BlogProject;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

			optionsBuilder.UseSqlServer("Server=tcp:hr-server.database.windows.net,1433;Database=Deneme1-HR;User ID=hrsqladmin;Password=Admin123;Trusted_Connection=false;TrustServerCertificate=False;MultipleActiveResultSets=true");
		}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
