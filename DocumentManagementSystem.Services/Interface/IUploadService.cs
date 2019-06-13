using DocumentManagementSystem.Models;

namespace DocumentManagementSystem.Services.Interface
{
    public interface IUploadService
    {
        bool AddDocument(Document document);
    }
}
