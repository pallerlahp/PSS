﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PSSEntities : DbContext
    {
        public PSSEntities()
            : base("name=PSSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PSS_Project_Category> PSS_Project_Category { get; set; }
        public virtual DbSet<PSS_Status> PSS_Status { get; set; }
        public virtual DbSet<PSS_User_Type> PSS_User_Type { get; set; }
        public virtual DbSet<PSS_Sponsor> PSS_Sponsor { get; set; }
        public virtual DbSet<PSS_Projects> PSS_Projects { get; set; }
        public virtual DbSet<PSS_Users> PSS_Users { get; set; }
        public virtual DbSet<PSS_Student_Project> PSS_Student_Project { get; set; }
    }
}
