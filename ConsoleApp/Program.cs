using System;
using DataModel;
using EFSqlTranslator.EFModels;
using EFSqlTranslator.Translation;
using EFSqlTranslator.Translation.DbObjects.SqliteObjects;
using Newtonsoft.Json;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                if (db.Database.EnsureDeleted() && db.Database.EnsureCreated())
                {
                    DbUtilis.CreateSqliteDb();
                    db.SaveChanges();
                }
            }

            using (var db = new BloggingContext())
            {
                var query = db.Blogs;

                var sql = "";
                try
                {
                    var blogs = db.Query(
                        query,
                        new EFModelInfoProvider(db),
                        new SqliteObjectFactory(),
                        out sql);

                    var json = JsonConvert.SerializeObject(blogs, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        Formatting = Formatting.Indented
                    });
                    
                    Console.WriteLine("Result:");
                    Console.WriteLine(json);
                }
                finally
                {
                    Console.WriteLine("Sql:");
                    Console.WriteLine(sql);
                }
            }
        }
    }
}
