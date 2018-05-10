using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Entity;
using Domain.Repository;

namespace Domain.Domain.Services
{
    public interface IImageItemService
    {
        void AddImage(ImageItem model);

        ImageItem GetImageById(int id);

        IEnumerable<object> GetImages();

        void UpdateImage(ImageItem model);
    }
}
