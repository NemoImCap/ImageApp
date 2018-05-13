using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Domain.Context;
using Domain.Domain.Services;
using Domain.Repository;
using Domain.Services;

namespace Web.ImageApplication
{
    public static class ConfigContainer
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();


            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ImageAppDBContext>().AsSelf().InstancePerLifetimeScope();

            // Generic Repository Registration
            builder.RegisterGeneric(typeof(Repository<>)).AsSelf();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();

            builder.RegisterType<ImagaItemService>().As<IImageItemService>().InstancePerRequest();
            // BUILD THE CONTAINER
            var container = builder.Build();


            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}