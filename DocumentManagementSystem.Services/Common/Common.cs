using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Services
{
    public class Common
    {
        public static int LIMITED_FILE_SIZE = 20480;

        public static string[] GetDocumentTypes(string s, string condition)
        {
            string[] arr = { };
            int postion = s.IndexOf(condition);
            if (postion < 0)
            {
                arr = new string[] { s, DocumentType.folder.ToString() };
                return arr;
            }
            else
            {
                string name = s.Substring(0, postion);
                string type = s.Substring(postion + 1);
                foreach (var item in Enum.GetNames(typeof(DocumentType)))
                {
                    if (type.Equals(item))
                    {
                        arr = new string[] { name, type };
                        return arr;
                    }
                }
                return null;
            }

        }

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

    }
}
