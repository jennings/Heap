//------------------------------------------------------------------------------------
// <copyright file="DetailsDiagnosisViewModel.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Web.ViewModels.Diagnosis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Heap.Web.Models.Entities;

    public class EditDiagnosisViewModel : Diagnosis
    {
        public IQueryable<Question> SuggestedQuestions { get; set; }
    }
}