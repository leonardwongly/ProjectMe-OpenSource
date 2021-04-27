using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        copyYear.Text = "2017 - " + DateTime.Now.Year.ToString();
    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        Response.ContentType = "Application/pdf";
        Response.AppendHeader("Content-Disposition", string.Format("attachment;filename=Resume-{0}.pdf", Guid.NewGuid().ToString()));
        Response.TransmitFile(Server.MapPath("~/resume-pdf-format.pdf"));
        Response.End();
    }
}
