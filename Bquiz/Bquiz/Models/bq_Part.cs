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
    
    public partial class bq_Part
    {
        public bq_Part()
        {
            this.bq_Part1 = new HashSet<bq_Part>();
            this.bq_QuestionGroup = new HashSet<bq_QuestionGroup>();
        }
    
        public byte PartId { get; set; }
        public Nullable<byte> ParentId { get; set; }
        public string Name { get; set; }
        public Nullable<byte> Order { get; set; }
        public byte NumberOfItems { get; set; }
        public string EdittingUrl { get; set; }
        public string PublishingUrl { get; set; }
    
        public virtual ICollection<bq_Part> bq_Part1 { get; set; }
        public virtual bq_Part bq_Part2 { get; set; }
        public virtual ICollection<bq_QuestionGroup> bq_QuestionGroup { get; set; }
    }
}
