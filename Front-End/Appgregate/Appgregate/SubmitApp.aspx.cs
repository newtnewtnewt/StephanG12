using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data.SqlClient;


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
          using(SqlConnection con = new SqlConnection(@"Data Source=MSSQL1;Initial Catalog=AppTable;"))
          {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tbllogin values(@N, @Des, @Org, @Plt, @Ver, @R)",con);
            cmd.Parameters.AddWithValue("N",Name.Text);
            cmd.Parameters.AddWithValue("Des",Description.Text);
            cmd.Parameters.AddWithValue("Org",Organization.Text);
            cmd.Parameters.AddWithValue("Plt",Platform.Text);
            cmd.Parameters.AddWithValue("Ver",Version.Text);
            cmd.Parameters.AddWithValue("R",Rating.Text);
            cmd.ExecuteNonQuery();

            Name.Text = "";
            Description.Text = "";
            Organization.Text = "";
            Platform.Text = "";
            Version.Text = "";
            Rating.Text = "";
            Name.Focus();
          }
            //Write SQL storage query right here, check for validations, show something on the Webpage if necessary
        }
    }
}
