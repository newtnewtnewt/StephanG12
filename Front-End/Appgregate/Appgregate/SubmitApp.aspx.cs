using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Appgregate
{
    public partial class SubmitApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Don't Touch this
        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
          {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO AppRequests values(@N, @Des, @Org, @Plt, @Ver)",con);
            cmd.Parameters.AddWithValue("N",Name.Text);
            cmd.Parameters.AddWithValue("Des",Description.Text);
            cmd.Parameters.AddWithValue("Org",Organization.Text);
            cmd.Parameters.AddWithValue("Plt",Platform.Text);
            cmd.Parameters.AddWithValue("Ver",Version.Text);
            //    int rating;
            //    int.TryParse(Rating.Text, out rating);
            //cmd.Parameters.AddWithValue("R",5);
            cmd.ExecuteNonQuery();

            Name.Text = "";
            Description.Text = "";
            Organization.Text = "";
            Platform.Text = "";
            Version.Text = "";
            //Rating.Text = "";
            Name.Focus();
            con.Close();
          }
          
            //Write SQL storage query right here, check for validations, show something on the Webpage if necessary
        }
    }
}
