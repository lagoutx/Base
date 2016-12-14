using Base.Services.Services;
using Base.Services.Services.EF;
using SimpleInjector;

namespace Base.Services
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
