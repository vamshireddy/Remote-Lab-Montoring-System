using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace labMonitoring
{
    public partial class Faculty_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * Set the error label invisible and button enabled*/
            Label1.Visible = false;
            Button1.Enabled = true;
            /*
             * Check if the user has already logged in 
             */
            if (Session["sessID"] == null)
            {
                Response.Redirect("Faculty_login.aspx");
            }
            if (!IsPostBack)
            {
                /*
                 * Populate the Labs
                 */
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select labID from Computer group by labID", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                // Add a dummy item
                ListItem i = new ListItem();
                i.Text = "Select";
                i.Value = "-1";
                DropDownList1.Items.Add(i);
                // Now populate from the database
                while (reader.Read())
                {
                    i = new ListItem();
                    i.Text = (string)reader["labID"];
                    i.Value = (string)reader["labID"];
                    DropDownList1.Items.Add(i);
                }
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["labname"] = DropDownList1.SelectedValue;
            Session["compname"] = DropDownList2.SelectedItem.Text;
            Response.Redirect("Output_Page.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            /*
             * Populate the Computers
             */
            string labID = DropDownList1.SelectedItem.Value;

            if (labID == "-1")
            {
                Label1.Visible = true;
                Button1.Enabled = false;
                return;
            }

            ClientNodeList computers = Global.labListGlobal.getLabComputers(labID);

            if (computers != null)
            {
                foreach( ClientNode node in computers.list )
                {
                    // TODO : MAC to be added to value
                    DropDownList2.Items.Add(new ListItem(node.name,node.mac.ToString()));
                }
                if (DropDownList2.Items.Count == 0)
                {
                    Label1.Visible = true;
                    Button1.Enabled = false;
                    Button1.BackColor = System.Drawing.Color.Gray;
                }
            }
            else
            {
                Label1.Visible = true;
                Button1.Enabled = false;
                Button1.BackColor = System.Drawing.Color.Gray;
            }
        }
    }
}