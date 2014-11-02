using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace labMonitoring
{
    public partial class Faculty_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            /*
             * Check if the user has already logged in 
             */
            if (Session["sessID"] == null)
            {
                Response.Redirect("Faculty_login.aspx");
            }
            /*
             * Populate the Labs
             */
            SqlConnection con = new SqlConnection("data source=.;initial catalog=vamshi;user id=sa;password=sajalsuraj;integrated security=true");
            SqlCommand cmd = new SqlCommand("select labID from Computers group by labID", con);
            con.Open();
            DropDownList1.DataSource = cmd.ExecuteReader();
            DropDownList1.DataTextField = "labID";
            DropDownList1.DataValueField = "labID";
            this.DataBind();
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Output_Page.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * Populate the Computers
             */
            string labID = DropDownList1.Items[DropDownList1.SelectedIndex].Value;
            ClientNodeList computers = null;
            foreach (ClientNodeList list in Global.labListGlobal.lab_list)
            {
                if (list.lab_name == labID)
                {
                    computers = list;
                    break;
                }
            }
            if (computers != null)
            {
                foreach( ClientNode node in computers.list )
                {
                    // TODO : MAC to be added to value
                    DropDownList2.Items.Add(new ListItem(node.name,""));
                }
            }
            else
            {
                Label1.Visible = true;
                Button1.Enabled = false;
            }
        }
    }
}