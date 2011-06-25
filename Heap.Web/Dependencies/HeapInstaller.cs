//------------------------------------------------------------------------------------
// <copyright file="HeapInstaller.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Web.Dependencies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Heap.Models.Repositories;

    public class HeapInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            var connectionStringParameter = Parameter.ForKey("connectionString").Eq(System.Configuration.ConfigurationManager.ConnectionStrings["HeapEntities"].ConnectionString);

            container.Register(AllTypes.FromAssemblyContaining<IHeapRepository>()
                                       .BasedOn<IHeapRepository>().WithService.Base()
                                       .Configure(component => component.Parameters(connectionStringParameter)
                                                                        .LifeStyle.PerWebRequest));

            container.Register(AllTypes.FromThisAssembly().BasedOn<IController>()
                                       .Configure(component => component.LifeStyle.PerWebRequest));
        }
    }
}