<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PennHospitality._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom:20px; border-bottom:solid 1px #eee;">
		<center><img src="Images/PennRelaysHeader.png" width="85%" /></center>
    </div>

	<%if ( Context.User.IsInRole("User") || Context.User.IsInRole("Admin") ) {%>
		<div class="row">
			<div class="col-md-4">
					<h2>Lookup</h2>
					<p>
						Lookup invitee information and tickets
					</p>
					<p>
						<a class="btn btn-primary" href="AdminPortal.aspx">Invitee Lookup &raquo;</a>
					</p>
			</div>
			<div class="col-md-4">
				
					<h2>Party View</h2>
					<p>
						Lookup and dislay entire party view
					</p>
					<p>
						<a class="btn btn-primary" href="AdminPortal.aspx">Party View &raquo;</a>
					</p>
			
			</div>
			<div class="col-md-4">
				<%if (Context.User.IsInRole("Admin")) {%>
					<h2>Admin Portal</h2>
					<p>
						Admin only features
					</p>
					<a class="btn btn-primary" href="AdminPortal.aspx">Admin Portal &raquo;</a>
				
				<%}%>
			</div>
		</div>
	<%} else {%>
		<%if(Context.User.Identity.IsAuthenticated){%>
			 <span style="color:red; font-weight:bold;">You are not authenticated to use this system. Contact a system administrator for further instructions</span>
		<%} else {%>
			<a href="Account/Login">Log in &raquo;</a> to use system
		<%}%>
	<%}%>

</asp:Content>
