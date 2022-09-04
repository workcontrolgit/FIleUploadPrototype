using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadPrototype.Models
{
    class FileUploadInfo
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public decimal ContentLength { get; set; }
        public string Description { get; set; }
    }
}
