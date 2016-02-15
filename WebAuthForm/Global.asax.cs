using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using BusinessLayerLibrary.DAL;
using BusinessLayerLibrary.Facades;
using BusinessLayerLibrary.Infrastructure;


namespace WebAuthForm
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterType<Config>().As<IDbConfig>().InstancePerDependency();
            builder.RegisterType<UserFacade>().InstancePerDependency();
            builder.RegisterType<OfferFacade>().InstancePerDependency();
            builder.RegisterType<DataManagerFactory>().As<IDataManagerFactory>().InstancePerDependency();
            builder.RegisterType<SHA1CryptoServiceProvider>().As<HashAlgorithm>().InstancePerDependency();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerDependency();
            IContainer ioC = builder.Build();
            var res = new Autofac.Integration.Mvc.AutofacDependencyResolver(ioC);
            DependencyResolver.SetResolver(res);
        }
    }
}