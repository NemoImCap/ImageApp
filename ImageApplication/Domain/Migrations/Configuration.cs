using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using Domain.Context;
using Domain.Domain.Entity;

namespace Domain.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ImageAppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ImageAppDBContext context)
        {
            var root = Path.GetPathRoot(AppDomain.CurrentDomain.BaseDirectory);
            var getFiles = Directory.GetFiles(
                root + "\\ImageApplication\\DeployRepository\\ImageApplication\\Web.ImageApplication\\Content\\images");
            foreach (var path in getFiles)
            {
                var file = new FileStream(path, FileMode.Open);
                var bytes = new byte[file.Length];
                var model = new ImageItem
                {
                    ImageData = bytes,
                    Description = "DB init",
                    ImageMimeType = "image/jpeg"
                };
                file.Read(bytes, 0, (int) file.Length);
                context.Entry(model).State = EntityState.Added;
                context.ImageItems.Add(model);
            }
        }
    }
}