using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bquiz.Models;

namespace Bquiz.Models
{
    public class bq_Part8
    {
        public bq_QuestionGroup Group { get; set; }
        public List<bq_Question> QuestionList { get; set; }
    }
}