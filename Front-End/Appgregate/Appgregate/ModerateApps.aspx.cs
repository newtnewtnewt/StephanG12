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
    public partial class ModerateApps : System.Web.UI.Page
    {
        public Boolean Page_Load(object sender, EventArgs e)
        {
            return true;
        }
        protected void AcceptButton_Click(object sender, EventArgs e)
        {

        }
        protected void DenyButton_Click(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            Debug.WriteLine("Got here!");
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            {
                con.Open();
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView.Rows[rowIndex];
                if (e.CommandName == "Accept")
                {


                    SqlCommand cmd = new SqlCommand("INSERT INTO AppTable values(@N, @Des, @Org, @Plt, @Ver, @R, @com)", con);
                    Debug.Print(row.Cells[0].Text);
                    cmd.Parameters.AddWithValue("N", System.Web.HttpUtility.HtmlDecode(row.Cells[0].Text));
                    cmd.Parameters.AddWithValue("Des", System.Web.HttpUtility.HtmlDecode(row.Cells[1].Text));
                    cmd.Parameters.AddWithValue("Org", System.Web.HttpUtility.HtmlDecode(row.Cells[2].Text));
                    cmd.Parameters.AddWithValue("Plt", System.Web.HttpUtility.HtmlDecode(row.Cells[3].Text));
                    cmd.Parameters.AddWithValue("Ver", System.Web.HttpUtility.HtmlDecode(row.Cells[4].Text));
                    //    int rating;
                    //    int.TryParse(Rating.Text, out rating);
                    cmd.Parameters.AddWithValue("R", 5);
                    cmd.Parameters.AddWithValue("com", "View Comments");
                    cmd.ExecuteNonQuery();
                }

                SqlCommand cmd2 = new SqlCommand("DELETE FROM AppRequests WHERE name = @N AND Description = @Des" +
                   " AND Organization = @Org", con);
                  // "AND Platform(s) = @Plt and Version(s) = @Ver)", con);
                cmd2.Parameters.AddWithValue("N", System.Web.HttpUtility.HtmlDecode(row.Cells[0].Text));
                cmd2.Parameters.AddWithValue("Des", System.Web.HttpUtility.HtmlDecode(row.Cells[1].Text));
                cmd2.Parameters.AddWithValue("Org", System.Web.HttpUtility.HtmlDecode(row.Cells[2].Text));
                cmd2.Parameters.AddWithValue("Plt", System.Web.HttpUtility.HtmlDecode(row.Cells[3].Text));
                cmd2.Parameters.AddWithValue("Ver", System.Web.HttpUtility.HtmlDecode(row.Cells[4].Text));
                cmd2.ExecuteNonQuery();
                Response.Redirect("~/ModerateApps");

                con.Close();
            }
        }

}
}
