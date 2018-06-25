using System.Data.Entity;
using Domain.Domain.Entity;

namespace Domain.Context
{
    public class ImageAppDBContext : DbContext
    {
        public ImageAppDBContext() : base("TestConnection")
        {
        }

        public DbSet<ImageItem> ImageItems { get; set; }
    }
}