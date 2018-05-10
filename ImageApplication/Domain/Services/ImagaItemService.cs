using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Entity;
using Domain.Domain.Services;
using Domain.Repository;

namespace Domain.Services
{
    public class ImagaItemService : IImageItemService
    {
        private readonly IRepository<ImageItem> _imageItemRepository;

        public ImagaItemService(IRepository<ImageItem> imageItemRepository)
        {
            _imageItemRepository = imageItemRepository;
        }

        public void AddImage(ImageItem model)
        {
            try
            {
                if (model.ImageData.Length != 0)
                {
                   _imageItemRepository.Add(model);
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public ImageItem GetImageById(int id)
        {
            var item = _imageItemRepository.FirstOrDefault(x => x.Id == id);
            return item;
        }

        public IEnumerable<object> GetImages()
        {
            var list = _imageItemRepository.GetAll().Select(x=> new{Id = x.Id, Description = x.Description});
            return list;
        }

        public void UpdateImage(ImageItem model)
        {
            if (model != null)
            {
                _imageItemRepository.Update(model);
            }
        }
    }
}
