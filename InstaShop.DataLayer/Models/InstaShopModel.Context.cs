﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InstaShop.DataLayer.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class InstaShop_DBEntities : DbContext
    {
        public InstaShop_DBEntities()
            : base("name=InstaShop_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<PageGroup> PageGroup { get; set; }
        public virtual DbSet<PageComment> PageComment { get; set; }
        public virtual DbSet<AdminLogin> AdminLogin { get; set; }
    }
}
