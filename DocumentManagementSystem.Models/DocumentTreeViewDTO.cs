﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Models
{
    public partial class DocumentTreeViewDTO
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public int ParentId { get; set; }
    }
}
