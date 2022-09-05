namespace FileUploadPrototype.Models
{
    class AttachmentInfo
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public decimal ContentLength { get; set; }
        public string Description { get; set; }
    }
}
