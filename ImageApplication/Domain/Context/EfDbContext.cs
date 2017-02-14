using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Entity;

namespace Domain.Context
{
    public class EfDbContext : DbContext
    {
        public DbSet<ImageItem> ImageItems { get; set; }
        public DbSet<ImageDescription> ImageDescriptions { get; set; } 
    }
}
