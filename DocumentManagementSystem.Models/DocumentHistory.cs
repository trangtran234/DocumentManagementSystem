using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Models.Common;

namespace DocumentManagementSystem.Models
{
    public class DocumentHistory
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public Helper.HistoryAction ActionEvent { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        public virtual Account Account { get; set; }
        public virtual Document Document { get; set; }
    }
}
