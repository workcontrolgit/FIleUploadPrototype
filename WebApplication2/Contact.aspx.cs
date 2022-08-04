using System;
using System.Web.UI;

namespace FileUploadPrototype
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script> error('Item added to Cart')</script>", false);
        }
    }
}