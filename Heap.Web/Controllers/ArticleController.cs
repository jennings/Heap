//------------------------------------------------------------------------------------
// <copyright file="ArticleController.cs" company="Stephen Jennings">
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
    using Heap.Web.Models.DataModel;
    using Heap.Web.ViewModels.Article;

    public class ArticleController : Controller
    {
        private IHeapContext database;

        public ArticleController(IHeapContext context)
        {
            this.database = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var model = new DetailsArticleViewModel()
            {
                Article = new Models.Article()
                {
                    Id = Guid.NewGuid(),
                    Description = "This is a fake article",
                    Title = "Fake Article"
                }
            };
            return View(model);
        }
    }
}
