//------------------------------------------------------------------------------------
// <copyright file="SymptomSelectorViewModel.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Web.ViewModels.Shared.EditorTemplates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Heap.Web.Models.Entities;
    using System.ComponentModel;

    public class SymptomSelectorViewModel
    {
        public IEnumerable<Symptom> SelectedSymptoms { get; set; }

        public IEnumerable<Question> SuggestedQuestions { get; set; }
    }
}