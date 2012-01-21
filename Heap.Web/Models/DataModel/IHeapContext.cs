//------------------------------------------------------------------------------------
// <copyright file="IHeapContext.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Web.Models.DataModel
{
    using System;
    using System.Data.Entity;

    public interface IHeapContext
    {
        IDbSet<Article> Articles { get; set; }

        IDbSet<FlowchartPath> FlowchartPaths { get; set; }

        IDbSet<Flowchart> Flowcharts { get; set; }

        IDbSet<FlowchartStep> FlowchartSteps { get; set; }
    }
}
