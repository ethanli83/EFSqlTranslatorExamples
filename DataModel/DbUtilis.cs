namespace DataModel
{
    public class DbUtilis
    {
        public static void CreateSqliteDb()
        {
            using (var db = new BloggingContext())
            {
                if (db.Database.EnsureDeleted() && db.Database.EnsureCreated())
                {
                    UpdateData(db);
                    db.SaveChanges();
                }
            }
        }

        private static void UpdateData(BloggingContext db)
        {
            db.Users.Add(new User
            {
                UserId = 1,
                UserName = "Ethan Li"
            });

            db.Users.Add(new User
            {
                UserId = 2,
                UserName = "Feng Xu"
            });

            db.Blogs.Add(new Blog
            {
                BlogId = 1,
                Url = "ethan1.com",
                UserId = 1
            });

            db.Blogs.Add(new Blog
            {
                BlogId = 2,
                Url = "ethan2.com",
                UserId = 1
            });

            db.Blogs.Add(new Blog
            {
                BlogId = 3,
                Url = "ethan3.com",
                UserId = 1
            });

            db.Blogs.Add(new Blog
            {
                BlogId = 4,
                Url = "xu1.com",
                UserId = 2
            });

            db.Blogs.Add(new Blog
            {
                BlogId = 5,
                Url = "xu2.com",
                UserId = 2
            });

            db.Posts.Add(new Post
            {
                PostId = 1,
                Content = "Post 1",
                Title = "Title 1",
                BlogId = 1,
                UserId = 1
            });

            db.Posts.Add(new Post
            {
                PostId = 2,
                Content = "Post 2",
                Title = "Title 2",
                BlogId = 1,
                UserId = 1
            });

            db.Comments.Add(new Comment
            {
                CommentId = 1,
                UserId = 1,
                PostId = 1
            });
        }
    }
}