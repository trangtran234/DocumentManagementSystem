namespace DocumentManagementSystem.Models
{
    public class DocumentTag
    {
        public int DocumentId { get; set; }
        public int TagId { get; set; }
        public int Id { get; set; }

        public virtual Tag Tag { get; set; }
    }
}