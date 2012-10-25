//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bquiz.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class bq_Quiz
    {
        public bq_Quiz()
        {
            this.bq_Question = new HashSet<bq_Question>();
            this.bq_QuestionGroup = new HashSet<bq_QuestionGroup>();
            this.bq_Test = new HashSet<bq_Test>();
        }
    
        public System.Guid QuizId { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public string Name { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string FinanceCompany { get; set; }
        public string CompanyIcon { get; set; }
    
        public virtual bq_Part bq_Part { get; set; }
        public virtual ICollection<bq_Question> bq_Question { get; set; }
        public virtual ICollection<bq_QuestionGroup> bq_QuestionGroup { get; set; }
        public virtual ICollection<bq_Test> bq_Test { get; set; }
    }
}
