using System;
using System.IO;
using System.Web.UI;

namespace FileUploadPrototype
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "File Upload";
            rfvDescription.Enabled = true;
            rfvFileSelection.Enabled = true;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();

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


                        fuDocument.SaveAs(Server.MapPath("~/App_Data/") + fileNameWithExtension);
                        StatusLabel.Text = "Upload status: File uploaded!";
                    }
                    catch (Exception ex)
                    {
                        StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
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
            rfvDescription.Enabled = false;
            rfvFileSelection.Enabled = false;
        }
    }
}