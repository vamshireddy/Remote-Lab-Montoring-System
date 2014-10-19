using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace labMonitoring
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (Session["homepage"] != null)
            {
                Response.Redirect(Session["homepage"].ToString());
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("main.aspx");
        }
    }
}