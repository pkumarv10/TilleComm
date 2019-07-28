using System.Web.Mvc;
using TilleComm.BusinessServvice.Concrete;
using TilleComm.BusinessServvice.Interfaces;
using Unity;
using Unity.Mvc5;

namespace TilleComm
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ILoginBusinessService, LoginBusinessService>();
            container.RegisterType<IProductsBusinessService, ProductsBusinessService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}