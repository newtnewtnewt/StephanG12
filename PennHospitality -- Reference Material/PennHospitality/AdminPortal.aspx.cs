using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PennHospitality
{
    public partial class AdminPortal : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Admin")) Response.Redirect("~/default.aspx");

            loadTicketData();
            loadUsers();

        }

        private void loadTicketData()
        {

        }

        private void loadUsers()
        {
            TableRow row;
            TableCell cell;


            foreach (DS.spGetUserListRow usr in (new DSTableAdapters.spGetUserListTableAdapter()).GetData())
            {
                {
                    row = new TableRow();
                    cell = new TableHeaderCell();
                    cell.Text = "<a href =\"#\" onclick = 'showToast(\"hey it works\");return false;'>" + usr.securityLevel + "</a>";
                    row.ID = usr.Id;
                    cell.Text = usr.UserName;
                    row.Cells.Add(cell);
                    tblUserList.Rows.Add(row);

                    cell = new TableCell();
                    cell.Text = "<a href=\"#\">" + usr.securityLevel + "</a>";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Cells.Add(cell);
                    tblUserList.Rows.Add(row);

                    cell = new TableCell();
                    if (!User.Identity.Name.Equals(usr.UserName))
                        cell.Text = "<img style=\"cursor:pointer;\" src=\"/Images/icons8-trash-24.png\" onclick=\"deleteSystemUser('" + usr.Id + "');\" />";
                    else
                        cell.Text = "";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Cells.Add(cell);

                    tblUserList.Rows.Add(row);
                }

            }
        }
    }
}
