using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace labMonitoring
{
    public partial class Faculty_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String name = username_faculty.Text;
            String pass = pass_faculty.Text;

            if (name == "vamshi" && pass == "reddy")
            {
                Response.Redirect("Faculty_Home.aspx");
            }
        }
    }
}