using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace labMonitoring
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<String> labs;
        List<String> computers;

        public WebForm1()
        {
            labs = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                labs.Add("Lab : "+(i + 1) + "");
            }
            computers = new List<string>();
            for (int i = 0; i < 25; i++)
            {
                computers.Add("System : "+(i + 1) + "");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["homepage"] == null)
            {
                Response.Redirect("main.aspx");
            }
            DropDownList1.DataSource = labs;
            DropDownList2.DataSource = computers;
            DropDownList1.DataBind();
            DropDownList2.DataBind(); 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}