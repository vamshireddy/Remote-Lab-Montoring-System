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
    public partial class Faculty_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Text = "Please Login to continue";
            Label4.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String name = username_faculty.Text;
            String pass = pass_faculty.Text;

            SqlConnection con = new SqlConnection("data source=.;initial catalog=vamshi;user id=sa;password=sajalsuraj;integrated security=true");
            SqlCommand cmd = new SqlCommand("select facultyID from FacultyLogin where facultyID='" + name + "' and facultyPassword='" + pass+"'", con);
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == false)
            {
                /*
                 * Invalid username and password */
                Label4.Visible = true;
            }
            else
            {
                /*
                 * User name and password are correct
                 */
                Session["sessID"] = name;
                Response.Redirect("Faculty_Home.aspx");
            }
            con.Close();
        }
    }
}