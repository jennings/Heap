//------------------------------------------------------------------------------------
// <copyright file="DiagnosisController.cs" company="Stephen Jennings">
//   Copyright 2011 Stephen Jennings. Licensed under the Apache License, Version 2.0.
// </copyright>
//------------------------------------------------------------------------------------

namespace Heap.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Heap.Web.Models.Entities;
    using Heap.Web.Models.Repositories;
    using Heap.Web.ViewModels.Diagnosis;
    using MvcMiniProfiler;

    public class DiagnosisController : Controller
    {
        private IHeapRepository repository;
        private MiniProfiler profiler = MiniProfiler.Current;

        public DiagnosisController(IHeapRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var model = new IndexDiagnosisViewModel()
            {
                Diagnoses = this.repository.GetDiagnoses()
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = new DetailsDiagnosisViewModel()
            {
                Diagnosis = this.repository.GetDiagnosis(id)
            };

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var diagnosis = new Diagnosis();

            if (TryUpdateModel(diagnosis, new string[] { "Query" }))
            {
                diagnosis.CreatedDate = DateTime.Now;
                this.repository.Save(diagnosis);
                return RedirectToAction("Details", new { id = diagnosis.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
