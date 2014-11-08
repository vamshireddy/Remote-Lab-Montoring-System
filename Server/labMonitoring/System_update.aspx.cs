using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace labMonitoring
{
    public partial class System_update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Insert(object sender, EventArgs e)
        {
            SqlDataSource1.Insert();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex != e.Row.RowIndex)
            {
                (e.Row.Cells[3].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }
    }
}