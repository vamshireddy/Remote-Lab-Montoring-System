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
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<String> labs;
        List<String> computers;

        public WebForm1()
        {
            labs = new List<string>();
            labs.Add("CG");
            labs.Add("OS");
            labs.Add("SE");
            labs.Add("NW");

            computers = new List<string>();
            for (int i = 0; i < 25; i++)
            {
                computers.Add("PC-"+(i + 1) + "");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sessID"] == null)
            {
                Response.Redirect("main.aspx");
            }
            if (!IsPostBack)
            {
                DropDownList1.DataSource = labs;
                DropDownList2.DataSource = computers;
                DropDownList1.DataBind();
                DropDownList2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Store the values in database
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into Computer values('" + DropDownList2.SelectedItem.Text + "','" + TextBox1.Text + "','" + DropDownList1.SelectedItem.Text + "')", con);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            if (a <= 0)
            {
                Label3.Text = "Could not add the Computer. Please check your fields";    
            }
            else
            {
                Response.Redirect("System_registration_succesfull.aspx");
                // Now add the Lab to the lab list
                Global.populateLabs();
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}