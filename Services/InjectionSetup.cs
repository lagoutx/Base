using Base.Services.EF;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services.Services
{
    public static class InjectorSetup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public static void Register(Container container)
        {
            container.Register<ITestService, TestService>(Lifestyle.Transient);
        }
    }
}
