//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Page
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Page()
        {
            this.PageComment = new HashSet<PageComment>();
        }
    
        public int PageID { get; set; }
        public int GroupID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Phone { get; set; }
        public string Bio { get; set; }
        public string Description { get; set; }
        public bool ShowInSlider { get; set; }
        public Nullable<int> Visit { get; set; }
        public string Tags { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    
        public virtual PageGroup PageGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PageComment> PageComment { get; set; }
    }
}
