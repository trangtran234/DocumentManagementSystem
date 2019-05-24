using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Repository.Interface
{
    public interface IDocumentContext: IDisposable
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<DocumentTag> DocumentTags { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<DocumentContent> DocumentContents { get; set; }
        DbSet<DocumentTerm> DocumentTerms { get; set; }

        void SaveChanges();
    }
}
