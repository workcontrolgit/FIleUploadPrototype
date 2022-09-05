using FileUploadPrototype.Interfaces;
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

            FileUploadControl.UploadEventHandler += new EventHandler(UploadEventHandler);
        }

        void UploadEventHandler(object sender, EventArgs e)
        {
            ShowUploadFiles();
        }



        private void ShowUploadFiles()
        {
            var fileUploadInfo = new FileUploadInfo();
            fileUploadInfo.FileName = FileUploadControl.FileName;
            fileUploadInfo.ContentType = FileUploadControl.ContentType;
            fileUploadInfo.ContentLength = FileUploadControl.ContentLength;
            fileUploadInfo.Description = FileUploadControl.Description;

            Attachment attachment = new Attachment();
           


            gridFiles.DataSource = attachment.Get(fileUploadInfo); 
            gridFiles.DataBind();

        }


        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            // prompt user to screen to upload file
            FileUploadControl.ShowUploadModal();
        }

        protected void lnkFileName_Click(object sender, EventArgs e)
        {
            // Reference sender object as link button
            LinkButton lnkbtn = sender as LinkButton;

            // Get the value passed from gridview
            string fileName = lnkbtn.CommandArgument.ToString();

            string serverFilePath = Server.MapPath(ConfigurationManager.AppSettings["UploadFilePath"] + "\\" + fileName);

            Attachment attachment = new Attachment();
            attachment.Download(Page, serverFilePath, fileName);
        }
    }
}