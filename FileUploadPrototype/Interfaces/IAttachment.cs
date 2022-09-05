
using FileUploadPrototype.Models;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUploadPrototype.Interfaces
{
    internal interface IAttachment
    {
        //void Delete();        
        void Add(FileUpload controlName, string filePath);
        void Download(Page page, string serverFilePath, string fileName);
        IEnumerable<FileUploadInfo> Get(FileUploadInfo fileUploadInfo);
    }
}
