//------------------------------------------------------------------------------------
// <copyright file="SqlServerHeapRepository.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Web.Models.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;

    public class SqlServerHeapRepository : IHeapRepository
    {
        private HeapDbContext context;

        public SqlServerHeapRepository(string connectionString)
        {
            this.context = new HeapDbContext(connectionString);
        }

        public Entities.Diagnosis GetDiagnosis(int id)
        {
            return this.context.Diagnoses.Find(id);
        }

        public IQueryable<Entities.Diagnosis> GetDiagnoses()
        {
            return this.context.Diagnoses;
        }

        public Entities.Question GetQuestion(int id)
        {
            return this.context.Questions.Find(id);
        }

        public IQueryable<Entities.Question> GetQuestions()
        {
            return this.context.Questions;
        }

        public void InsertOrUpdate(Entities.Diagnosis diagnosis)
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
        }

        public void InsertOrUpdate(Entities.Symptom symptom)
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
        }

        public void InsertOrUpdate(Entities.Question question)
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
        }

        public void InsertOrUpdate(Entities.Article article)
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
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
