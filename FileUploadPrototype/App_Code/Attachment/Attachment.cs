using FileUploadPrototype.Interfaces;
using FileUploadPrototype.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

class Attachment : IAttachment
{

    public void Add(FileUpload controlName, string filePath)
    {
        controlName.SaveAs(filePath);
    }
    public void Download(Page page, string serverFilePath, string fileName)
    {
        System.Net.WebClient client = new System.Net.WebClient();
        Byte[] buffer = client.DownloadData(serverFilePath);
        if (buffer != null)
        {
            page.Response.ContentType = "application/octect-stream";
            page.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            page.Response.AddHeader("content-length", buffer.Length.ToString());
            page.Response.BinaryWrite(buffer);
        }

    }
    public IEnumerable<AttachmentInfo> Get(AttachmentInfo fileUploadInfo)
    {
        List<AttachmentInfo> lisFileUpload = new List<AttachmentInfo>();
        lisFileUpload.Add(fileUploadInfo);
        return lisFileUpload;
    }

}