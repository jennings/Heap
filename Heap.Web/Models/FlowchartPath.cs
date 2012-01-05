//------------------------------------------------------------------------------------
// <copyright file="FlowchartPath.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class FlowchartPath
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual Flowchart Flowchart { get; set; }

        public virtual FlowchartStep Source { get; set; }

        public virtual FlowchartStep Target { get; set; }
    }
}