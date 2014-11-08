using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace labMonitoring
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bu1_Click(object sender, EventArgs e)
        {
            if (Session["type"] == null)
            {
                Response.Redirect("Main.aspx");
            }
            else if (Session["type"] == "faculty")
            {
                Response.Redirect("Faculty_Home.aspx");
            }
            else if (Session["type"] == "admin")
            {
                Response.Redirect("Admin_Home.aspx");
            }
        }

        protected void bu2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Main.aspx");
        }
    }
}