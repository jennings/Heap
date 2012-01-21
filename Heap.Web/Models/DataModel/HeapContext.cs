//------------------------------------------------------------------------------------
// <copyright file="HeapContext.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Web.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;

    public class HeapContext : DbContext, IHeapContext
    {
        public HeapContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Flowchart> Flowcharts { get; set; }

        public IDbSet<FlowchartStep> FlowchartSteps { get; set; }

        public IDbSet<FlowchartPath> FlowchartPaths { get; set; }
    }
}