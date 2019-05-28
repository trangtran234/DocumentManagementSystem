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
        public string DocumentDescription { get; set; }
        public string Created { get; set; }
        public string LastModified { get; set; }
        public virtual Account CreatedBy { get; set; }
        public virtual Account LastModifiedBy { get; set; }
        public byte[] DocumentContent { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public int CreateByID { get; set; }
        public int LastModifiedByID { get; set; }
        public System.Guid DocumentContentId { get; set; }
        public int ParentId { get; set; }

        public virtual ICollection<DocumentType> DocumentTypes { get; set; }
    }
}
