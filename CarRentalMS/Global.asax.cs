using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using CarRentalMS.DataAccess.Infrastructure;
using CarRentalMS.DataAccess.Infrastructure.Interfaces;
using CarRentalMS.DataAccess.Repositories;
using CarRentalMS.DataAccess.Repositories.Interfaces;
using CarRentalMS.Infrastructure;
using CarRentalMS.Services;
using CarRentalMS.Services.Interfaces;

namespace CarRentalMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            RegisterAutofac();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutomapperWebProfile.Run();
        }

        private void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterSource(new ViewRegistrationSource());

            //manual registration of types
            builder.RegisterType<CarServices>().As<ICarServices>();
            builder.RegisterType<CompanyServices>().As<ICompanyServices>();
            builder.RegisterType<AccountServices>().As<IAccountServices>();
            builder.RegisterType<CarRepository>().As<ICarRepository>();
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>();
            builder.RegisterType<AccountRepository>().As<IAccountRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
