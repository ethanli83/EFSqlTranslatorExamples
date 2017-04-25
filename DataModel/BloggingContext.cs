﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataModel
{
    public class BloggingContext : DbContext
    {
        public const string ConnectionString = "Filename=./blog.db";

        public DbSet<Blog> Blogs { get; set; }
        
        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Statistic> Statistics { get; set; }

        public DbSet<Foo> Foos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        
        public string Url { get; set; }
        
        public string Name { get; set; }
        
        public int UserId { get; set; }
        
        public User User { get; set; }
        
        public List<Post> Posts { get; set; } = new List<Post>();

        public List<Statistic> Statistics { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public int BlogId { get; set; }

        public int UserId { get; set; }
        
        public User User { get; set; }

        public Blog Blog { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }

    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public List<Blog> Blogs { get; set; } = new List<Blog>();

        public List<Post> Posts { get; set; } = new List<Post>();

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }

    public class Comment
    {
        public int CommentId { get; set; }

        public int? UserId { get; set; }

        public int PostId { get; set; }

        public User User { get; set; }

        public Post Post { get; set; }
    }

    public class Statistic
    {
        public int StatisticId { get; set; }

        public int ViewCount { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }
    }

    public class Foo
    {
        public int FooId { get; set; }

        public string FooCol { get; set; }
    }
}
