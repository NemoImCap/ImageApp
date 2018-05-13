using System.Data.Entity;
using Domain.Domain.Entity;

namespace Domain.Context
{
    public class ImageAppDBContext : DbContext
    {
        public DbSet<ImageItem> ImageItems { get; set; }
    }
}