using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Models
{
    public class DocumentTreeView
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public int ParentId { get; set; }
        public List<DocumentTreeView> Childrens { get; set; }
    }
}
