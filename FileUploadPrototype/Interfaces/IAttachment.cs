
using FileUploadPrototype.Models;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUploadPrototype.Interfaces
{
    internal interface IAttachment
    {
        void Add(FileUpload controlName, string filePath);
        void Download(Page page, string serverFilePath, string fileName);
        IEnumerable<AttachmentInfo> Get(AttachmentInfo fileUploadInfo);
        // TODO
        //void Delete();  
    }
}
