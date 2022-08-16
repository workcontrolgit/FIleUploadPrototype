using FileUploadPrototype.Models;
using System;
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
        }

        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            //set the modal form title via code behind
            lblModalTitle.Text = "File Upload";
            //enable validation of controls on the file upload form
            SetFormValidation(true);
            //display modal via code on the server side
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upFileUploadModal.Update();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            if (fuAttachment.HasFile)
            {
                try
                {

                    var uploadFile = new FileUploadInfo();
                    uploadFile.FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                    uploadFile.ContentType = fuAttachment.PostedFile.ContentType;
                    uploadFile.ContentLength = fuAttachment.PostedFile.ContentLength;

                    ShowFileUploadStatus(uploadFile);

                    // get setting from web.config
                    string uploadFilePath = ConfigurationManager.AppSettings["UploadFilePath"];

                    fuAttachment.SaveAs(Server.MapPath(uploadFilePath) + uploadFile.FileName);
                    // toaster to diplay success
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script> success('File uploaded')</script>", false);
                    // reset validation controls
                    SetFormValidation(false);
                }
                catch (Exception ex)
                {
                    // toaster to diplay error
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script> err('File not uploaded')</script>", false);
                    throw ex;
                }
            }
        }

        private void ShowFileUploadStatus(FileUploadInfo uploadFile)
        {
            litFileName.Text = uploadFile.FileName;
            litContentType.Text = uploadFile.ContentType;
            litFileSize.Text = uploadFile.ContentLength.ToString();
            litDescription.Text = txtDescription.Text;
            lnkDownload.Visible = true;
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
        //Function for File Download in ASP.Net in C# and 
        //Tracking the status of success/failure of Download.
        private bool DownloadFile(string fileName)
        {
            //File Path and File Name
            string filePath = Server.MapPath(ConfigurationManager.AppSettings["UploadFilePath"]);

            FileInfo fileInfo = new FileInfo(filePath + "\\" + fileName);
            FileStream fileStream = new FileStream(filePath + "\\" + fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Reads file as binary values
            BinaryReader _BinaryReader = new BinaryReader(fileStream);

            //Check whether file exists in specified location
            if (fileInfo.Exists)
            {
                try
                {
                    long startBytes = 0;
                    string fileDate = File.GetLastWriteTimeUtc(filePath).ToString("r");
                    string encodedData = HttpUtility.UrlEncode(fileName, Encoding.UTF8) + fileDate;

                    Response.Clear();
                    Response.Buffer = false;
                    Response.AddHeader("Accept-Ranges", "bytes");
                    Response.AppendHeader("ETag", "\"" + encodedData + "\"");
                    Response.AppendHeader("Last-Modified", fileDate);
                    //Response.ContentType = "application/octet-stream";
                    Response.ContentType = litContentType.Text;
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
                    Response.AddHeader("Content-Length", (fileInfo.Length - startBytes).ToString());
                    Response.AddHeader("Connection", "Keep-Alive");
                    Response.ContentEncoding = Encoding.UTF8;

                    //Read data
                    _BinaryReader.BaseStream.Seek(startBytes, SeekOrigin.Begin);

                    //Dividing the data in 1024 bytes package
                    int maxCount = (int)Math.Ceiling((fileInfo.Length - startBytes + 0.0) / 1024);

                    //Download in block of 1024 bytes
                    int i;
                    for (i = 0; i < maxCount && Response.IsClientConnected; i++)
                    {
                        Response.BinaryWrite(_BinaryReader.ReadBytes(1024));
                        Response.Flush();
                    }
                    //if blocks transfered not equals total number of blocks
                    if (i < maxCount)
                        return false;
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    Response.End();
                    _BinaryReader.Close();
                    fileStream.Close();
                }
            }
            else ScriptManager.RegisterStartupScript(this, GetType(),
                "FileNotFoundWarning", "alert('File is not available now!')", true);

            return false;
        }


        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            bool isSuccess = DownloadFile(litFileName.Text);

        }
    }
}