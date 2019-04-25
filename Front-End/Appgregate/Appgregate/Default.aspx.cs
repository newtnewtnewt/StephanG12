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
        public Boolean Page_Load(object sender, EventArgs e)
        {
            return true;
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((string)e.CommandName != "Sort")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView.Rows[rowIndex];
                //This saves the appID to the user's current session
                Session["appID"] = GridView.DataKeys[rowIndex]["appID"];
                Response.Redirect("~/AppComments.aspx");
            }
        }

        protected void ViewComments_Click(object sender, EventArgs e)
        {

        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectParameters.Clear();
            string query = txtSearch.Text;
            query = query.Replace("'", "''");
            SqlDataSource1.SelectParameters.Add("query", query);
            SqlDataSource1.SelectCommand = "SELECT AppTable.appID, AppTable.Name, AppTable.Description, AppTable.Organization, AppTable.[Platform(s)], AppTable.[Version(s)], " + 
                "[Rating] = (CASE WHEN AVG(appRating) < 1 OR AVG(appRating) IS NULL  THEN 'N/A' ELSE CONVERT(VARCHAR(5), CAST(AVG(CAST(appRating AS DECIMAL(10, 2))) AS DECIMAL(10, 2))) END) " + 
               "FROM AppTable LEFT JOIN CommentsTable ON CommentsTable.appID = AppTable.appID " +
                "WHERE AppTable.Name LIKE '%" + query + "%' OR " +
                "AppTable.Description LIKE '%" + query + "%' OR " + 
                "AppTable.Organization LIKE '%" + query + "%' OR " +
                "AppTable.[Platform(s)] LIKE '%" + query + "%' OR " +
                "AppTable.[Version(s)] LIKE '%" + query + "%' " +
                "GROUP BY AppTable.appID, AppTable.Name, AppTable.Description, AppTable.Organization, AppTable.[Platform(s)], AppTable.[Version(s)], AppTable.appID " +
                "UNION " + 
                "SELECT AppTable.appID, AppTable.Name, AppTable.Description, AppTable.Organization, AppTable.[Platform(s)], AppTable.[Version(s)], " +
                "[Rating] = (CASE WHEN AVG(appRating) < 1 OR AVG(appRating) IS NULL  THEN 'N/A' ELSE CONVERT(VARCHAR(5), CAST(AVG(CAST(appRating AS DECIMAL(10,2))) AS DECIMAL(10,2))) END) " + 
                "FROM AppTable LEFT JOIN CommentsTable ON CommentsTable.appID = AppTable.appID " +
                "GROUP BY AppTable.appID, AppTable.Name, AppTable.Description, AppTable.Organization, AppTable.[Platform(s)], AppTable.[Version(s)], AppTable.appID " +
                "HAVING CAST(AVG(CAST(appRating AS DECIMAL(10,2))) AS DECIMAL(10,2)) LIKE '%" + query +"%' " +
				"UNION " +
                "SELECT AppTable.appID, AppTable.Name, AppTable.Description, AppTable.Organization, AppTable.[Platform(s)], AppTable.[Version(s)], " + 
                "[Rating] = (CASE WHEN AVG(appRating) < 1 OR AVG(appRating) IS NULL  THEN 'N/A' ELSE CONVERT(VARCHAR(5), CAST(AVG(CAST(appRating AS DECIMAL(10,2))) AS DECIMAL(10,2))) END) " + 
                "FROM AppTable LEFT JOIN CommentsTable ON CommentsTable.appID = AppTable.appID " +
               "GROUP BY AppTable.appID, AppTable.Name, AppTable.Description, AppTable.Organization, AppTable.[Platform(s)], AppTable.[Version(s)], AppTable.appID " +
               "HAVING (AVG(appRating) < 1 OR AVG(appRating) IS NULL) AND 'N/A'  LIKE '%" + query + "%' "; 
            SqlDataSource1.DataBind();
            //GridView.DataBind();

        }
    }
}