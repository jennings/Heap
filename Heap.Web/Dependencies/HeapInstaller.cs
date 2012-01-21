﻿//------------------------------------------------------------------------------------
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
    using Heap.Web.Models.DataModel;
    using MvcMiniProfiler.Data;

    public class HeapInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            var baseConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HeapEntities"].ConnectionString;
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HeapEntities"].ConnectionString;

            container.Register(Component.For<IDbConnectionFactory>()
                                        .ImplementedBy<SqlConnectionFactory>()
                                        .DependsOn(Dependency.OnValue("baseConnectionString", baseConnectionString)));

            container.Register(AllTypes.FromThisAssembly()
                                       .BasedOn<IHeapContext>().WithService.Base()
                                       .LifestylePerWebRequest()
                                       .Configure(component => component.DependsOn(Dependency.OnValue("nameOrConnectionString", connectionString))));

            container.Register(AllTypes.FromThisAssembly()
                                       .BasedOn<IController>()
                                       .LifestylePerWebRequest());
        }
    }
}