using System.Web.Mvc;

namespace Domain.Domain.Entity
{
    public class ImageItem
    {
        public int Id { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        [AllowHtml]
        public string Description { get; set; }
    }
}