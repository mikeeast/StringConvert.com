using Microsoft.Practices.ServiceLocation;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.StructureMap;
using Nancy.Conventions;
using Nancy.Session;
using Nancy.ViewEngines.Razor;
using StringConvert.WebClient.Converting;
using StringConvert.WebClient.Converting.Converters;
using StructureMap.ServiceLocatorAdapter;

namespace StringConvert.WebClient
{
    public class Bootstrapper : StructureMapNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(StructureMap.IContainer existingContainer)
        {
            existingContainer.Configure(c => 
                c.Scan(s => {
                    s.AssemblyContainingType<IConvertStrings>();
                    s.IncludeNamespaceContainingType<Md5Encoder>();
                    s.AddAllTypesOf<IConvertStrings>();
                    s.RegisterConcreteTypesAgainstTheFirstInterface();
                    s.WithDefaultConventions().OnAddedPluginTypes(t => t.Singleton());
            }));
            existingContainer.Configure(a => a.For<IRazorConfiguration>().Singleton().Use<RazorConfiguration>());
            existingContainer.Configure(c => c.For<IConverterRepository>().Singleton().Use<ConverterRepository>());
            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator(existingContainer));
            base.ConfigureApplicationContainer(existingContainer);
        }

        protected override void ApplicationStartup(StructureMap.IContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            StaticConfiguration.DisableCaches = true;
            StaticConfiguration.DisableErrorTraces = false;

            this.Conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Scripts"));

            CookieBasedSessions.Enable(pipelines);
        }
    }
}