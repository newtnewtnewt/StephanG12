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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e) { 
        //{

          
        //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //    {
        //        con.Open();
        //        int rowIndex = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow row = GridView.Rows[rowIndex];
        //        if (e.CommandName == "Accept")
        //        {


        //            SqlCommand cmd = new SqlCommand("INSERT INTO AppTable values(@N, @Des, @Org, @Plt, @Ver, @R, @com)", con);
        //            cmd.Parameters.AddWithValue("N", row.Cells[0].Text);
        //            cmd.Parameters.AddWithValue("Des", row.Cells[1].Text);
        //            cmd.Parameters.AddWithValue("Org", row.Cells[2].Text);
        //            cmd.Parameters.AddWithValue("Plt", row.Cells[3].Text);
        //            cmd.Parameters.AddWithValue("Ver", row.Cells[4].Text);
        //            //    int rating;
        //            //    int.TryParse(Rating.Text, out rating);
        //            cmd.Parameters.AddWithValue("R", 5);
        //            cmd.Parameters.AddWithValue("com", "View Comments");
        //            cmd.ExecuteNonQuery();
        //        }

        //        SqlCommand cmd2 = new SqlCommand("DELETE FROM AppRequests WHERE name = @N AND Description = @Des" +
        //           " AND Organization = @Org", con);
        //        // "AND Platform(s) = @Plt and Version(s) = @Ver)", con);
        //        cmd2.Parameters.AddWithValue("N", row.Cells[0].Text);
        //        cmd2.Parameters.AddWithValue("Des", row.Cells[1].Text);
        //        cmd2.Parameters.AddWithValue("Org", row.Cells[2].Text);
        //        cmd2.Parameters.AddWithValue("Plt", row.Cells[3].Text);
        //        cmd2.Parameters.AddWithValue("Ver", row.Cells[4].Text);
        //        cmd2.ExecuteNonQuery();
        //        Response.Redirect("~/ModerateApps");

        //        con.Close();
        //    }
        }
        protected void ViewComments_Click(object sender, EventArgs e)
        {

        }
    }
}