using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heap.Web.ViewModels.Question
{
    public class IndexQuestionViewModel
    {
        public IEnumerable<Heap.Web.Models.Entities.Question> Questions { get; set; }
    }
}