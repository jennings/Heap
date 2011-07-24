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
    using MvcMiniProfiler;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    /// The application's HttpApplication class.
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        internal static WindsorContainer Container { get; private set; }

        /// <summary>
        /// Registers global filters.
        /// </summary>
        /// <param name="filters">The global collection of filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        /// <summary>
        /// Registers routes for the application.
        /// </summary>
        /// <param name="routes">The application's RouteCollection.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "Default-Entity",
                "{controller}/{id}/{action}",
                new { action = "Details" },
                new { id = @"\d+" });

            routes.MapRoute(
                "Default-Generic",
                "{controller}/{action}",
                new { controller = "Diagnosis", action = "Index" });
        }

        /// <summary>
        /// The application's startup routine.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            this.ConfigureDependencyInjection();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(typeof(Controllers.WindsorControllerFactory));
        }

        protected void Application_End()
        {
            MvcApplication.Container.Dispose();
        }

        protected void Application_BeginRequest()
        {
            MiniProfiler.Start();
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }

        private void ConfigureDependencyInjection()
        {
            MvcApplication.Container = new WindsorContainer();
            MvcApplication.Container.Install(Castle.Windsor.Installer.FromAssembly.This());

            var factory = MvcApplication.Container.Resolve<System.Data.Entity.Infrastructure.IDbConnectionFactory>();
            System.Data.Entity.Database.DefaultConnectionFactory = new MvcMiniProfiler.Data.ProfiledDbConnectionFactory(factory);
        }
    }
}