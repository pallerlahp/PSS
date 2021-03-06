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
    
    public partial class PSS_User_Type
    {
        public PSS_User_Type()
        {
            this.PSS_Users = new HashSet<PSS_Users>();
        }
    
        public int user_type_id { get; set; }
        
        [Required(ErrorMessage="Please enter User Type")]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Please enter a valid user type")]
        public string type { get; set; }
        public Nullable<bool> active { get; set; }
    
        public virtual ICollection<PSS_Users> PSS_Users { get; set; }
    }
}
