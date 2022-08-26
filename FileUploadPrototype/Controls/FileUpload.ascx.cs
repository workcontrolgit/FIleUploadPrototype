using System;
using System.Configuration;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUploadPrototype.Controls
{
    public partial class FileUpload : System.Web.UI.UserControl
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
            double filesize = fuAttachment.FileContent.Length;

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

            if (fuAttachment.HasFile)
            {
                try
                {

                    //var uploadFile = new FileUploadInfo();
                    FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                    ContentType = fuAttachment.PostedFile.ContentType;
                    ContentLength = fuAttachment.PostedFile.ContentLength;
                    Description = txtDescription.Text.Trim();


                    // get setting from web.config
                    string uploadFilePath = ConfigurationManager.AppSettings["UploadFilePath"];

                    fuAttachment.SaveAs(Server.MapPath(uploadFilePath) + FileName);
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
        public void ShowFileUpload()
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