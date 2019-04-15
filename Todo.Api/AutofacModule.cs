using Autofac;
using Autofac.Configuration;
using Autofac.Core;
using Microsoft.Extensions.Configuration;
using Todo.Api.Controllers;

namespace Todo.Api
{
    public partial class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /* builder.RegisterType<Display>().As<IDisplay>()
                 .WithParameter("signo", "####")
                 .WithProperty("Upper", true)
                 .SingleInstance();

     */
            builder.RegisterModule<Log4NetModuleConfig>();
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("Autofac.json");
            builder.RegisterModule(new ConfigurationModule(configBuilder.Build()));
        }
    }
}