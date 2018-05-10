using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Domain.Domain.Entity;
using Domain.Domain.Services;
using Domain.Services;
using MetadataExtractor;

namespace Web.ImageApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IImageItemService _imageItemService;

        public HomeController(IImageItemService imageItemService)
        {
            _imageItemService = imageItemService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetAllImages()
        {
            var list = _imageItemService.GetImages();
            return Json(list,JsonRequestBehavior.AllowGet);
        }

        public FileContentResult GetImage(int id)
        {
            var entity = _imageItemService.GetImageById(id);
            if (entity != null)
            {
                return File(entity.ImageData, entity.ImageMimeType);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateFile(int id, string description = "")
        {
            var item = _imageItemService.GetImageById(id);
            if (item != null)
            {
                item.Description = description;
                _imageItemService.UpdateImage(item);
            }
            else
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json("Upload failed");
            }
            return Json("Success");
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<JsonResult> UploadFile(string description = "")
        {
            try
            {
                var image = Request.Files[0];
                if (image != null)
                {
                    var model = new ImageItem
                    {
                        ImageData = new byte[image.ContentLength],
                        ImageMimeType = image.ContentType,
                        Description = description
                    };
                    image.InputStream.Read(model.ImageData, 0, image.ContentLength);
                    _imageItemService.AddImage(model);
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json("Upload failed");
            }
            return Json("File uploaded successfully");
        }
    }
}