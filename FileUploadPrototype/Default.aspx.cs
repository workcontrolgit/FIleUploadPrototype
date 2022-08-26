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

            FileUpload.UploadEventHandler += new EventHandler(UploadEventHandler);
        }

        void UploadEventHandler(object sender, EventArgs e)
        {
            ShowFileUploadStatus();
        }



        private void ShowFileUploadStatus()
        {
            litFileName.Text = FileUpload.FileName;
            litContentType.Text = FileUpload.ContentType;
            litFileSize.Text = FileUpload.ContentLength.ToString();
            litDescription.Text = FileUpload.Description;
            lnkDownload.Visible = true;
        }


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

        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            FileUpload.ShowFileUpload();
        }
    }
}