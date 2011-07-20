//------------------------------------------------------------------------------------
// <copyright file="IndexDiagnosisViewModel.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Web.ViewModels.Diagnosis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class IndexDiagnosisViewModel
    {
        public IEnumerable<Heap.Web.Models.Entities.Diagnosis> Diagnoses { get; set; }
    }
}