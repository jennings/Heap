//------------------------------------------------------------------------------------
// <copyright file="Symptom.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Web.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Symptom
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Question Question { get; set; }
    }
}
