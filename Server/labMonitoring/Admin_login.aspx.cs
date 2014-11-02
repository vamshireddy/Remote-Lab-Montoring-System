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
            /*
             * Now validate the username and password */
            SqlConnection con = new SqlConnection("data source=.;initial catalog=vamshi;user id=sa;password=sajalsuraj;integrated security=true");
            SqlCommand cmd = new SqlCommand("select adminID from AdminLogin where adminID=@uname and password=@paswd",con);
            con.Open();
            cmd.Parameters.AddWithValue("uname", username);
            cmd.Parameters.AddWithValue("paswd", password);

            SqlDataReader reader =  cmd.ExecuteReader();

            if (reader.Read() == false)
            {
                /*
                 * Invalid username and password */
                Label2.Visible = true;
            }
            else
            {
                /*
                 * User name and password are correct
                 */
                Session["sessID"] = username;
                Response.Redirect("Admin_Home.aspx");
            }
            con.Close();
        }
    }
}