using FileUploadPrototype.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUploadPrototype
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            FileUpload.UploadEventHandler += new EventHandler(UploadEventHandler);
        }

        void UploadEventHandler(object sender, EventArgs e)
        {
            ShowFileUploadStatus();
        }



        private void ShowFileUploadStatus()
        {
            List<FileUploadInfo> lisFileUpload = new List<FileUploadInfo>();
            var fileUploadInfo = new FileUploadInfo();
            //using (var fileUploadInfo = new FileUploadInfo())
            //{
            //}
            fileUploadInfo.FileName = FileUpload.FileName;
            fileUploadInfo.ContentType = FileUpload.ContentType;
            fileUploadInfo.ContentLength = FileUpload.ContentLength;
            fileUploadInfo.Description = FileUpload.Description;

            lisFileUpload.Add(fileUploadInfo);

            gridFiles.DataSource = lisFileUpload;
            gridFiles.DataBind();

        }


        private void DownloadAttachment(string fileName)
        {
            string path = Server.MapPath(ConfigurationManager.AppSettings["UploadFilePath"] + "\\" + fileName);
            System.Net.WebClient client = new System.Net.WebClient();
            Byte[] buffer = client.DownloadData(path);
            if (buffer != null)
            {
                Response.ContentType = "application/octect-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }

        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            FileUpload.ShowFileUpload();
        }

        protected void lnkFileName_Click(object sender, EventArgs e)
        {
            //Create the object
            LinkButton lnkbtn = sender as LinkButton;

            //Get the value passed from gridview
            string fileName = lnkbtn.CommandArgument.ToString();

            DownloadAttachment(fileName);
        }
    }
}