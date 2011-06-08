//------------------------------------------------------------------------------------
// <copyright file="Question.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Question
    {
        public virtual int Id { get; set; }

        public virtual string Description { get; set; }

        public virtual ICollection<Symptom> Symptoms { get; set; }
    }
}
