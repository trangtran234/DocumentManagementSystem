using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public double DocumentSize { get; set; }
        public byte[] DocumentDescription { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public int CreateBy { get; set; }
        public int LastModifiedBy { get; set; }
        public Guid DocumentContentId { get; set; }
    }
}
