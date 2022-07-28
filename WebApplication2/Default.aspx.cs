using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUploadPrototype
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "File Upload";
            lblModalBody.Text = "Type";
            txtFileType.Text = "PDAT Form";
            rfvFileType.Enabled = true;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuSelectFile.HasFile)
                {
                    try
                    {
                        string filename = Path.GetFileName(fuSelectFile.FileName);
                        fuSelectFile.SaveAs(Server.MapPath("~/App_Data/") + filename);
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
            rfvFileType.Enabled = false;
        }
    }
}