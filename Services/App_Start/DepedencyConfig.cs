using Base.DAL;
using Base.DAL.Models;
using Base.DAL.Models.EF;
using Base.Services.Services;
using Base.Services.Services.EF;
using SimpleInjector;
using System.Data.Entity;

namespace Base.Services
{
    public static class DependencyConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public static void Register(Container container)
        {
            container.RegisterPerWebRequest<DbContext>(() => new BaseContext("name=DefaultConnection"));
            container.RegisterPerWebRequest<BaseContext>(() => new BaseContext("name=DefaultConnection"));

            container.Register<IDataContext<BaseContext>, DataContext<BaseContext, BaseContext>>();
            container.Register<ITestService, TestService>(Lifestyle.Transient);
        }
    }
}
