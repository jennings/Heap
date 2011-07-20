//------------------------------------------------------------------------------------
// <copyright file="HeapInstaller.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Web.Dependencies
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Heap.Web.Models.Repositories;
    using MvcMiniProfiler.Data;

    public class HeapInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            var baseConnectionStringParameter = Parameter.ForKey("baseConnectionString").Eq(System.Configuration.ConfigurationManager.ConnectionStrings["HeapEntities"].ConnectionString);
            var connectionStringParameter = Parameter.ForKey("connectionString").Eq(System.Configuration.ConfigurationManager.ConnectionStrings["HeapEntities"].ConnectionString);

            container.Register(Component.For<IDbConnectionFactory>()
                                        .ImplementedBy<SqlConnectionFactory>()
                                        .Parameters(baseConnectionStringParameter));

            container.Register(AllTypes.FromThisAssembly()
                                       .BasedOn<IHeapRepository>().WithService.Base()
                                       .Configure(component => component.Parameters(connectionStringParameter)
                                                                        .LifeStyle.PerWebRequest));

            container.Register(AllTypes.FromThisAssembly()
                                       .BasedOn<IController>()
                                       .Configure(component => component.LifeStyle.PerWebRequest));
        }
    }
}