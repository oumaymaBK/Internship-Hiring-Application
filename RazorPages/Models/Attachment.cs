namespace RazorPages.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string OriginalFileName { get; set; }
        public string StorageFileName { get; set; }
        //navigation property ici on a foreign key 
        public int ContactId {  get; set; }

    }
}