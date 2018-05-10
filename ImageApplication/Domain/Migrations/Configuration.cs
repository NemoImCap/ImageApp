using System.IO;
using System.Reflection;
using Domain.Context;
using Domain.Domain.Entity;

namespace Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EfDbContext context)
        {
            var root = Path.GetPathRoot(AppDomain.CurrentDomain.BaseDirectory);
            var getFiles = Directory.GetFiles(root + "\\ImageApplication\\DeployRepository\\ImageApplication\\Web.ImageApplication\\Content\\images");
            foreach (var path in getFiles)
            {
                var file = new FileStream(path, FileMode.Open);
                byte[] bytes = new byte[file.Length];
                var model = new ImageItem
                {
                    ImageData = bytes,
                    Description = "DB init",
                    ImageMimeType = "image/jpeg"
                };
                file.Read(bytes, 0, (int)file.Length);
                context.Entry(model).State = System.Data.Entity.EntityState.Added;
                context.ImageItems.Add(model);
            }
        }
    }
}
