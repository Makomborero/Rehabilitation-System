//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASPGMaps
{
    using System;
    using System.Collections.Generic;
    
    public partial class question
    {
        public int question_id { get; set; }
        public string question_name { get; set; }
        public string option_one { get; set; }
        public string option_two { get; set; }
        public string option_three { get; set; }
        public string option_four { get; set; }
        public Nullable<int> question_answer { get; set; }
        public Nullable<int> exam_fid { get; set; }
    }
}