using FileUploadPrototype.Models;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUploadPrototype
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            //set the modal form title via code behind
            lblModalTitle.Text = "File Upload";
            //enable validation of controls on the file upload form
            SetValidation(true);
            //display modal via code on the server side
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upFileUploadModal.Update();

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuDocument.HasFile)
                {
                    try
                    {
                        // get file name with extension
                        string fileNameWithExtension = Path.GetFileName(fuDocument.PostedFile.FileName);
                        // get file name without extension  
                        string fileName = Path.GetFileNameWithoutExtension(fileNameWithExtension);
                        // get file extension (pdf, jpg, etc.)
                        string fileExtension = Path.GetExtension(fileNameWithExtension);
                        // get file content type  
                        string fileContentType = fuDocument.PostedFile.ContentType;
                        // get file size  
                        int fileSize = fuDocument.PostedFile.ContentLength;

                        var uploadFile = new FileUploadInfo();
                        uploadFile.FileName = Path.GetFileName(fuDocument.PostedFile.FileName);
                        uploadFile.ContentType = fuDocument.PostedFile.ContentType;
                        uploadFile.ContentLength = fuDocument.PostedFile.ContentLength;

                        string tempFileExtension = uploadFile.GetFileExtension();


                        fuDocument.SaveAs(Server.MapPath("~/App_Data/") + fileNameWithExtension);
                        StatusLabel.Text = String.Format("File uploaded : {0}", uploadFile.FileName);
                        // toaster
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script> success('File uploaded')</script>", false);
                        // reset validation controls
                        SetValidation(false);

                    }
                    catch (Exception ex)
                    {
                        StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script> err('File not uploaded')</script>", false);
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SetValidation(false);
        }
        protected void SetValidation(bool value)
        {
            rfvDescription.Enabled = value;
            rfvFileSelection.Enabled = value;
            revFileType.Enabled = value;
            cvFileUpload.Enabled = value;
        }

        protected void checkfilesize(object source, ServerValidateEventArgs args)
        {
            string data = args.Value;
            args.IsValid = false;
            double filesize = fuDocument.FileContent.Length;
            if (filesize > 50000)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}