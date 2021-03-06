//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PSS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class PSS_Status
    {
        public PSS_Status()
        {
            this.PSS_Projects = new HashSet<PSS_Projects>();
            this.PSS_Student_Project = new HashSet<PSS_Student_Project>();
        }
    
        public int status_id { get; set; }
        [Required(ErrorMessage = "Please enter Status name")]
        public string status { get; set; }
        [Required(ErrorMessage = "Please select type")]
        public Nullable<bool> type { get; set; }
        public Nullable<bool> active { get; set; }
    
        public virtual ICollection<PSS_Projects> PSS_Projects { get; set; }
        public virtual ICollection<PSS_Student_Project> PSS_Student_Project { get; set; }
    }
}
