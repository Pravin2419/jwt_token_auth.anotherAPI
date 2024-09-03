using System;
using System.Collections.Generic;

namespace jwt_token_auth.anotherAPI.Models
{
    public partial class DocumentAttachment
    {
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public string FileExtension { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public DateTime DateUploaded { get; set; }
    }
}
