<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPortal.aspx.cs" Inherits="PennHospitality.AdminPortal" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
	<div class="blockArea" style="margin-top:22px;">
		<h3 style="border-bottom:solid 1px #eee;font-weight:bold;color:#A51E36;">Tools / Reports</h3>
		<div class="row" style="font-size:1.1em;">
			<div class="col-md-3" style="padding-bottom:3px;">
				<a href="#" class="btn btn-primary">Add/Edit/Delete Invitee &raquo;</a>
			</div>
			<div class="col-md-3" style="padding-bottom:3px;">
				<a href="#" class="btn btn-primary">Database Lookup &raquo;</a>
			</div>
			<div class="col-md-3" style="padding-bottom:3px;">
				<a href="#" class="btn btn-primary""></a>
			</div>
			<div class="col-md-3" style="padding-bottom:3px;">
				<a href="#" class="btn btn-primary"></a>
			</div>
			
		</div>
	</div>

	<div class="blockArea">
		<h3 style="border-bottom:solid 1px #eee;font-weight:bold;color:#A51E36;">Tickets</h3>
		<table runat="server" id="tblTickets" class="table table-striped table-bordered">
			<thead>
				<tr align="center">
					<th></th>
					<th style="text-align:center;">Thursday</th>
					<th style="text-align:center;">Friday</th>
					<th style="text-align:center;">Saturday</th>
				</tr>
			</thead>
			<tr>
				<th class="text-nowrap">Needed</th>
				<td style="text-align:center;"><asp:Label ID="lblTicketsNeededTh" runat="server" Text="0"></asp:Label></td>
				<td style="text-align:center;"><asp:Label ID="lblTicketsNeededFr" runat="server" Text="0"></asp:Label></td>
				<td style="text-align:center;"><asp:Label ID="lblTicketsNeededSa" runat="server" Text="0"></asp:Label></td>
			</tr>
			<tr>
				<th class="text-nowrap">Picked Up</th>
				<td style="text-align:center;"><asp:Label ID="lblTicketsPickedUpTh" runat="server" Text="0"></asp:Label></td>
				<td style="text-align:center;"><asp:Label ID="lblTicketsPickedUpFr" runat="server" Text="0"></asp:Label></td>
				<td style="text-align:center;"><asp:Label ID="lblTicketsPickedUpSa" runat="server" Text="0"></asp:Label></td>
			</tr>
			<tr>
				<th class="text-nowrap">Remaining</th>
				<td style="text-align:center;"><asp:Label ID="lblTicketsRemainingTh" runat="server" Text="0"></asp:Label></td>
				<td style="text-align:center;"><asp:Label ID="lblTicketsRemainingFr" runat="server" Text="0"></asp:Label></td>
				<td style="text-align:center;"><asp:Label ID="lblTicketsRemainingSa" runat="server" Text="0"></asp:Label></td>
			</tr>
		</table>
		
	</div>

	<div class="blockArea">
		<h3 style="border-bottom:solid 1px #eee;font-weight:bold;color:#A51E36;">System User List</h3>

		<asp:Table runat="server" id="tblUserList" class="table table-striped table-bordered">
			<asp:TableHeaderRow>
				<asp:TableHeaderCell>User</asp:TableHeaderCell>
				<asp:TableHeaderCell style="text-align:center;">Rights</asp:TableHeaderCell>
				<asp:TableHeaderCell HorizontalAlign="Center" Width="48">Action</asp:TableHeaderCell>
			</asp:TableHeaderRow>
		</asp:Table>
	</div>

	<!--=========================================================================================================================================-->
	<div class="modal fade" id="modalDeleteMember" role="dialog">
		<div class="modal-dialog modal-sm">
		  <div class="modal-content">
			<div class="modal-header">
			  <button type="button" class="close" data-dismiss="modal">&times;</button>
			  <h4 class="modal-title">System User List</h4>
			</div>
			<div class="modal-body">
			  <p>Are you sure you want to remove this user from the list?</p>
			</div>
			<div class="modal-footer">
			  <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
			  <button type="button" class="btn btn-success" data-dismiss="modal" onclick="javascript:doDelete();">Yes, Remove User</button>
			</div>
		  </div>
		</div>
	</div>

	<!--=========================================================================================================================================-->


	<script type="text/javascript">
		var uidToDelete = '';
		function deleteSystemUser(id) {
			uidToDelete = id;
			$('#modalDeleteMember').modal().show;			
		}

		function doDelete() {
			if (uidToDelete == '') return;

			var row = document.getElementById(uidToDelete);
			row.parentNode.removeChild(row);

			var url = "ws.asmx";
			$.ajax({
				type: "POST",
				url: url + "/deleteSystemUser",
				data: "{id:'" + uidToDelete + "'}",
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: OnSuccessCall,
				error: OnErrorCall
			});

			function OnSuccessCall(response) {
				showToast(response.d);
			}

			function OnErrorCall(response) {
				alert(response.status + " " + response.statusText);
			}
			uidToDelete = '';
		}

	</script>

    </asp:Content>