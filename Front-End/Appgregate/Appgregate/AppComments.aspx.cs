using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Diagnostics;
using System.Data;

namespace Appgregate
{
    public partial class AppComments : Page
    {
        public Boolean Page_Load(object sender, EventArgs e)
        {
            return true;
        }
        protected void DenyButton_Click(object sender, EventArgs e)
        {
      
        }
        int indexOfColumn = 3;
           /* This method prevents non-Moderators and Admins from seeing the delete button
            * 
            * */
        protected void Mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (!Context.User.IsInRole("Moderator") && !Context.User.IsInRole("Admin"))
            {
                e.Row.Cells[indexOfColumn].Visible = false;
            }
            
        }
        /*
         * This stores a user's comment in the table with the press of a submit button,
         * accounting for several cases including a rating with no comment, and a comment with no rating
         * 
         * */
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            int appIDSave = Convert.ToInt32(Session["appID"]);
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();

            if (txtComment.Text == "Feel Free To Leave a Comment" || txtComment.Text == "") 
            {
                if (ratingDrop.SelectedIndex != 0)
                {
                   
                    SqlCommand cmd = new SqlCommand("INSERT INTO CommentsTable values(@user, @appID, @appRating, @commentText)", con);
                    cmd.Parameters.AddWithValue("user", System.Web.HttpContext.Current.User.Identity.Name);
                    cmd.Parameters.AddWithValue("appID", appIDSave);
                    cmd.Parameters.AddWithValue("appRating", Convert.ToInt32(ratingDrop.SelectedValue));
                    cmd.Parameters.AddWithValue("commentText","No Comment");
                    cmd.ExecuteNonQuery();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }

            }
            else
            {
                if (ratingDrop.SelectedIndex == 0)
                {
                    
                    SqlCommand cmd = new SqlCommand("INSERT INTO CommentsTable values(@user, @appID, @appRating, @commentText)", con);
                    cmd.Parameters.AddWithValue("user", System.Web.HttpContext.Current.User.Identity.Name);
                    cmd.Parameters.AddWithValue("appID", appIDSave);
                    cmd.Parameters.AddWithValue("appRating", -1);
                    cmd.Parameters.AddWithValue("commentText", txtComment.Text);
                    cmd.ExecuteNonQuery();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO CommentsTable values(@user, @appID, @appRating, @commentText)", con);
                    cmd.Parameters.AddWithValue("user", System.Web.HttpContext.Current.User.Identity.Name);
                    cmd.Parameters.AddWithValue("appID", appIDSave);
                    cmd.Parameters.AddWithValue("appRating", ratingDrop.SelectedValue);
                    cmd.Parameters.AddWithValue("commentText", txtComment.Text);
                    cmd.ExecuteNonQuery();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }
        }

        /**
         * This is all the code that allows for the delete button provided to a Mod/Admin to
         * delete from a table
         * 
         * */
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int appID = Convert.ToInt32(Session["appID"]);
            SqlConnection con2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con2.Open();
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView.Rows[rowIndex];
            SqlCommand cmd2 = new SqlCommand("DELETE FROM CommentsTable WHERE username = @user AND appID = @aID" +
                  " AND appRating = @appR AND commentText = @comment", con2);
            cmd2.Parameters.AddWithValue("user", System.Web.HttpUtility.HtmlDecode(row.Cells[0].Text));

            cmd2.Parameters.Add("@aID", SqlDbType.Int);
            cmd2.Parameters["@aID"].Value = appID;

            if (row.Cells[2].Text == "N/A")
            {
                cmd2.Parameters.Add("@appR", SqlDbType.Int);
                cmd2.Parameters["@appR"].Value = -1;
            }
            else { 
                cmd2.Parameters.Add("@appR", SqlDbType.Int);
                cmd2.Parameters["@appR"].Value = Convert.ToInt32(row.Cells[2].Text);
            }

            cmd2.Parameters.AddWithValue("comment", System.Web.HttpUtility.HtmlDecode(row.Cells[1].Text));
            cmd2.ExecuteNonQuery();
            con2.Close();
            Debug.Print(System.Web.HttpUtility.HtmlDecode(row.Cells[0].Text));
            Debug.Print("" + appID);
            Debug.Print(System.Web.HttpUtility.HtmlDecode(row.Cells[2].Text));
            Debug.Print("" + row.Cells[1].Text.Length);
            Page.Response.Redirect(Page.Request.Url.ToString(), false);
        }

}
}
