using FileUploadPrototype.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUploadPrototype.Controls
{
    public partial class FileUpload : UserControl
    {
        #region Public Member  
        public string Description { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
        public string FileName { get; set; }


        public event EventHandler UploadEventHandler;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SetFormValidation(false);
        }

        protected void SetFormValidation(bool value)
        {
            rfvDescription.Enabled = value;
            rfvFileSelection.Enabled = value;
            revFileType.Enabled = value;
            cvFileUpload.Enabled = value;
        }

        protected void ValidateMaxFilesize(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            double filesize = fileAttachment.FileContent.Length;

            // get setting from web.config
            long maxFilesize = Convert.ToInt64((ConfigurationManager.AppSettings["MaxUploadFilesize"]));

            if (filesize > maxFilesize)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (fileAttachment.HasFile)
            {
                try
                {

                    //set public properties for parent page to consume
                    FileName = Path.GetFileName(fileAttachment.PostedFile.FileName);
                    ContentType = fileAttachment.PostedFile.ContentType;
                    ContentLength = fileAttachment.PostedFile.ContentLength;
                    Description = txtDescription.Text.Trim();


                    // get file upload setting from web.config
                    string uploadFilePath = ConfigurationManager.AppSettings["UploadFilePath"];

                    string serverFilePath = Server.MapPath(uploadFilePath + FileName);
                    // save file 
                    Attachment attachment = new Attachment();
                    attachment.Add(fileAttachment, serverFilePath);
                    
                    // toaster to diplay success
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script> success('File uploaded')</script>", false);
                    // reset validation controls
                    SetFormValidation(false);

                    UploadEventHandler(sender, e);

                }
                catch (Exception ex)
                {
                    // toaster to diplay error
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script> err('File not uploaded')</script>", false);
                    throw ex;
                }
            }
        }

        //public void btnFileUpload_Click(object sender, EventArgs e)
        public void ShowUploadModal()
        {
            //set the modal form title via code behind
            lblModalTitle.Text = "File Upload";
            //enable validation of controls on the file upload form
            SetFormValidation(true);
            //display modal via code on the server side
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upFileUploadModal.Update();
        }

    }


}