using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Heap.Web.Models.Repositories;
using MvcMiniProfiler;
using Heap.Web.ViewModels.Question;
using Heap.Web.Models.Entities;

namespace Heap.Web.Controllers
{
    public class QuestionController : Controller
    {
        private IHeapRepository repository;
        private MiniProfiler profiler = MiniProfiler.Current;

        public QuestionController(IHeapRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var model = new IndexQuestionViewModel()
            {
                Questions = this.repository.GetQuestions()
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = new DetailsQuestionViewModel()
            {
                Question = this.repository.GetQuestion(id)
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
            var question = new Question();

            if (TryUpdateModel(question, new string[] { "Description" }))
            {
                this.repository.InsertOrUpdate(question);
                this.repository.Save();
                return RedirectToAction("Details", new { id = question.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
