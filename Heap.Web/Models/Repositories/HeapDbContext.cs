//------------------------------------------------------------------------------------
// <copyright file="HeapDbContext.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Web.Models.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using Heap.Web.Models.Entities;

    internal class HeapDbContext : DbContext
    {
        public HeapDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public IDbSet<Diagnosis> Diagnoses { get; set; }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Question> Questions { get; set; }

        public IDbSet<Symptom> Symptoms { get; set; }
    }
}
