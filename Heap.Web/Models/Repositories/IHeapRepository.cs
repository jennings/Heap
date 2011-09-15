//------------------------------------------------------------------------------------
// <copyright file="IHeapRepository.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Web.Models.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Heap.Web.Models.Entities;

    public interface IHeapRepository
    {
        Diagnosis GetDiagnosis(int id);

        IQueryable<Diagnosis> GetDiagnoses();

        Question GetQuestion(int id);

        IQueryable<Question> GetQuestions();

        void InsertOrUpdate(Diagnosis diagnosis);

        void InsertOrUpdate(Symptom symptom);

        void InsertOrUpdate(Question question);

        void InsertOrUpdate(Article article);

        void Save();
    }
}
