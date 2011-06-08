//------------------------------------------------------------------------------------
// <copyright file="Diagnosis.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Diagnosis
    {
        public virtual int Id { get; set; }

        public virtual string Query { get; set; }

        public virtual ICollection<Symptom> SelectedSymptoms { get; set; }

        public virtual Article SuccessfulArticle { get; set; }

        public virtual ICollection<Article> UnsuccessfulArticles { get; set; }
    }
}
