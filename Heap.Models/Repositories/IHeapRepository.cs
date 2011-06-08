//------------------------------------------------------------------------------------
// <copyright file="IHeapRepository.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Models.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Heap.Models.Entities;

    public interface IHeapRepository
    {
        void Save(Diagnosis diagnosis);
        
        void Save(Symptom symptom);
        
        void Save(Question question);
        
        void Save(Article article);
    }
}
