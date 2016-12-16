using SimpleInjector;
using System.Web.Mvc;
using SimpleInjector.Integration.Web.Mvc;

namespace Base
{
    /// <summary>
    /// Simple Injector Dependency Config
    /// </summary>
    public static class DependencyConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Register()
        {
            // 1. Create a new Simple Injector container
            var container = new Container();

            // 2. Configure the container (register)
            // Service level items first
            Base.Services.DependencyConfig.Register(container);

            // 3. Optionally verify the container's configuration.
            container.Verify();

            // 4. Store the container for use by the application
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
}
