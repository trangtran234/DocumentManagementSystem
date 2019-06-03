using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Models.Common
{
    public class Helper
    {
        public const int FAKE_USERID_TO_EDIT = 4;
        public const int FAKE_USERID_TO_ADD_HISTORY = 1;
        public enum DocumentType
        {
            jpg,
            png,
            jpeg,
            bmp,
            gif,
            doc,
            docx,
            xls,
            xlsx,
            ppt,
            pptx,
            pdf,
            txt,
            rtf,
            css,
            folder
        }
        public enum HistoryAction
        {
            [Description("Upload")]
            Upload = 1,
            [Description("Edit")]
            Edit = 2,
            [Description("Delete")]
            Delete = 3
        }
    }
}
