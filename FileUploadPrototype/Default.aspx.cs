using FileUploadPrototype.Models;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUploadPrototype
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            AttachmentUserControl.UploadEventHandler += new EventHandler(UploadEventHandler);
        }

        void UploadEventHandler(object sender, EventArgs e)
        {
            // call the save attachment method in the file upload control
            AttachmentUserControl.SaveAttachment();
            // display the info of the attachment in the gridview
            ShowUploadFiles();
        }



        private void ShowUploadFiles()
        {
            // init model
            var fileUploadInfo = new AttachmentInfo();
            // set value of model members with user control public properties
            fileUploadInfo.FileName = AttachmentUserControl.FileName;
            fileUploadInfo.ContentType = AttachmentUserControl.ContentType;
            fileUploadInfo.ContentLength = AttachmentUserControl.ContentLength;
            fileUploadInfo.Description = AttachmentUserControl.Description;

            // init Attachment class to get list of files
            Attachment attachment = new Attachment();
            // bind grid view to list of files from attachment.Get method
            gridFiles.DataSource = attachment.Get(fileUploadInfo);
            gridFiles.DataBind();

        }


        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            // prompt screen to upload file
            AttachmentUserControl.ShowUploadModal();
        }

        protected void lnkFileName_Click(object sender, EventArgs e)
        {
            // Reference sender object as link button
            LinkButton lnkbtn = sender as LinkButton;

            // Get the value passed from gridview
            string fileName = lnkbtn.CommandArgument.ToString();

            string serverFilePath = Server.MapPath(ConfigurationManager.AppSettings["UploadFilePath"] + "\\" + fileName);
            //init instance of Attachment class
            Attachment attachment = new Attachment();
            // call the attachment download method to download the file
            attachment.Download(Page, serverFilePath, fileName);
        }
    }
}