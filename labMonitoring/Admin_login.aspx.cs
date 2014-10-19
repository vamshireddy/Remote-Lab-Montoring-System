using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace labMonitoring
{
    public partial class admin_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String username = un.Text;
            String password = pass.Text;

            if (username == "vamshi" && password == "reddy")
            {
                Session["UserAuthentication"] = username;
                Session["homepage"] = "WebForm1.aspx";
                Response.Redirect("WebForm1.aspx");
            }
            else
            {
                Label2.Visible = true;
            }

        }
    }
}