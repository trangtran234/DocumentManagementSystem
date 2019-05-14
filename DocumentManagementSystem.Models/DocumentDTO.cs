using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Models
{
    public class DocumentDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string FileType { get; set; }
        public string Created { get; set; }
        public string LastModified { get; set; }
    }
}
