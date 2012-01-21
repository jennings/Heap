//------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Castle.Windsor;

    //// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    //// visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        internal static WindsorContainer Container { get; private set; }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            this.ConfigureDependencyInjection();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(typeof(WindsorControllerFactory));
        }

        private void ConfigureDependencyInjection()
        {
            MvcApplication.Container = new WindsorContainer();
            MvcApplication.Container.Install(Castle.Windsor.Installer.FromAssembly.This());

            var factory = MvcApplication.Container.Resolve<System.Data.Entity.Infrastructure.IDbConnectionFactory>();
            // System.Data.Entity.Database.DefaultConnectionFactory = new MvcMiniProfiler.Data.ProfiledDbConnectionFactory(factory);
        }
    }
}