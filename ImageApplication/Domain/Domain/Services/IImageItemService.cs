using System.Collections.Generic;
using Domain.Domain.Entity;

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