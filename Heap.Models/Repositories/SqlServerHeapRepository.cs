//------------------------------------------------------------------------------------
// <copyright file="SqlServerHeapRepository.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Models.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SqlServerHeapRepository : IHeapRepository
    {
        private HeapDbContext context;

        public SqlServerHeapRepository(string connectionString)
        {
            this.context = new HeapDbContext(connectionString);
        }

        public void Save(Entities.Diagnosis diagnosis)
        {
            var original = this.context.Diagnoses.Find(diagnosis.Id);

            if (original == null)
            {
                this.context.Diagnoses.Add(diagnosis);
            }
            else
            {
                var entry = this.context.Entry(original);
                entry.OriginalValues.SetValues(original);
                entry.CurrentValues.SetValues(diagnosis);
            }

            this.context.SaveChanges();
        }

        public void Save(Entities.Symptom symptom)
        {
            var original = this.context.Diagnoses.Find(symptom.Id);

            if (original == null)
            {
                this.context.Symptoms.Add(symptom);
            }
            else
            {
                var entry = this.context.Entry(original);
                entry.OriginalValues.SetValues(original);
                entry.CurrentValues.SetValues(symptom);
            }

            this.context.SaveChanges();
        }

        public void Save(Entities.Question question)
        {
            var original = this.context.Diagnoses.Find(question.Id);

            if (original == null)
            {
                this.context.Questions.Add(question);
            }
            else
            {
                var entry = this.context.Entry(original);
                entry.OriginalValues.SetValues(original);
                entry.CurrentValues.SetValues(question);
            }

            this.context.SaveChanges();
        }

        public void Save(Entities.Article article)
        {
            var original = this.context.Diagnoses.Find(article.Id);

            if (original == null)
            {
                this.context.Articles.Add(article);
            }
            else
            {
                var entry = this.context.Entry(original);
                entry.OriginalValues.SetValues(original);
                entry.CurrentValues.SetValues(article);
            }

            this.context.SaveChanges();
        }
    }
}
