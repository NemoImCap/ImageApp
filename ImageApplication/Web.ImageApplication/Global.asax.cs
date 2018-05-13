using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Domain.Context;
using Domain.Domain.Entity;

namespace Web.ImageApplication
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ConfigContainer.Configure();
            //InitDb();
        }

        protected void InitDb()
        {
            var getFiles = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "\\Content\\images");
            foreach (var path in getFiles)
            {
                var file = new FileStream(path, FileMode.Open);
                byte[] bytes = new byte[file.Length];
                var model = new ImageItem
                {
                    ImageData = bytes,
                    Description = "Initializ db",
                    ImageMimeType = "image/jpeg"
                };
                file.Read(bytes, 0, (int)file.Length);
                using (var dbCtx = new ImageAppDBContext())
                {
                    dbCtx.Entry(model).State = System.Data.Entity.EntityState.Added;
                    dbCtx.ImageItems.Add(model);
                    dbCtx.SaveChanges();
                }
            }
        }
    }
}