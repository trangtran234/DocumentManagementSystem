using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Models
{
    public partial class DocumentTreeViewDTO
    {
        public List<DocumentTreeViewDTO> Childrens { get; set; }
    }
}
