using Autofac;
using Microsoft.Extensions.Logging;
using NetcoreMvc.AppService;
using NetcoreMvc.EntityFrameworkCore.Entities;
using NetcoreMvc.EntityFrameworkCore.Repositories;

namespace NetcoreMvc
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(IGenericRepository<>)).InstancePerRequest();
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method in ConfigureServices.
            builder.Register(c => new CityInfoService(c.Resolve<IGenericRepository<City>>()))
                .As<ICityInfoService>()
                .InstancePerRequest();
        }
    }
}