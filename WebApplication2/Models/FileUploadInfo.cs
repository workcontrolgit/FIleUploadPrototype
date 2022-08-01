using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileUploadPrototype.Models
{
    public class FileUploadInfo

    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
        public string GetFileExtension()
        {
            return Path.GetExtension(FileName);
        }        
        public string GetFileNameWithoutExtension()
        {
            return Path.GetFileNameWithoutExtension(FileName);
        }
    }
}