using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Diagnostics;

namespace Appgregate
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e) 
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView.Rows[rowIndex];
            //This saves the appID to the user's current session
            Session["appID"] = GridView.DataKeys[rowIndex]["appID"];
            Response.Redirect("~/AppComments.aspx"); 
        }

        protected void ViewComments_Click(object sender, EventArgs e)
        {

        }
    }
}