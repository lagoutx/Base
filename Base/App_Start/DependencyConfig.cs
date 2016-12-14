using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using SimpleInjector;
using System.Web.Mvc;
using SimpleInjector.Integration.Web.Mvc;
using Base.Services.Services;

namespace Base
{
    /// <summary>
    /// Simple Injector Dependency Config
    /// </summary>
    public static class DependencyConfig
    {

        public static void Register()
        {
            // 1. Create a new Simple Injector container
            var container = new Container();

            // 2. Configure the container (register)
            // See below for more configuration examples
            InjectorSetup.Register(container);

            // 3. Optionally verify the container's configuration.
            container.Verify();

            // 4. Store the container for use by the application
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
}
