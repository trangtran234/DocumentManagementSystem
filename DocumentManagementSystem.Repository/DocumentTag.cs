//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocumentManagementSystem.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class DocumentTag
    {
        public int DocumentId { get; set; }
        public int TagId { get; set; }
        public int Id { get; set; }
    
        public virtual Document Document { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
