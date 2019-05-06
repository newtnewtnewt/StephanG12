<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Appgregate._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- I build this class to provide a Grid/Table of all apps presents. Apps are loaded in from a dummy/future working database 
         stored under "App Data" called "AppList". The view comments button needs to be adjusted to link to custom Comments pages.
        
        --%>
      
  <br />
  <br />
      <div class="input-btn-toolbar" style="width:100%">  
        <asp:TextBox ID="txtSearch" runat="server" Rows="1" Columns="20" Width="600px" Text="Type and Search!" style="resize:none;vertical-align:middle" />  
        <asp:Button ID="SubmitSearch" style ="vertical-align:middle" CssClass = "Button"  runat="server"   Text="Submit"  OnClick="SubmitButton_Click" />
       </div>
    <br />
    <br />

    <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="appID" DataSourceID="SqlDataSource1" OnRowCommand ="GridView1_RowCommand" AllowSorting ="true" >
        <Columns>
        <%-- Our Gridview accounts for Name, Description, Organization, Platform, Versions, Rating, and Comments.Th
             All data and headers are centered, and space is provided appropriately for the content of each column.
            --%>
         <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" SortExpression="Name" ></asp:BoundField>
         <asp:BoundField DataField="Description"  HeaderStyle-CssClass="text-center"  ItemStyle-HorizontalAlign="Center" HeaderText="Description" ItemStyle-Width="30%" SortExpression="Description" ></asp:BoundField>
         <asp:BoundField DataField="Organization" HeaderStyle-CssClass="text-center"  ItemStyle-HorizontalAlign="Center" HeaderText="Organization" ItemStyle-Width="15%" SortExpression="Organization" ></asp:BoundField>
         <asp:BoundField DataField="Platform(s)"  HeaderStyle-CssClass="text-center"  ItemStyle-HorizontalAlign="Center" HeaderText="Platform(s)" ItemStyle-Width="15%" SortExpression="Platform(s)" > </asp:BoundField>
         <asp:BoundField DataField="Version(s)" HeaderStyle-CssClass="text-center"  ItemStyle-HorizontalAlign="Center" HeaderText="Version(s)" ItemStyle-Width="15%" SortExpression="Version(s)" ></asp:BoundField>
         <asp:BoundField DataField="Rating"     HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderText="Rating" ItemStyle-Width="10%" SortExpression="Rating" ></asp:BoundField>
         <asp:TemplateField HeaderText=""  HeaderStyle-CssClass="text-center"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30%" SortExpression="View Comments">
                 <ItemTemplate>
                      <asp:LinkButton ID="ViewCommentsButton" CssClass = "Button"  runat="server"   Text="View Comments"  OnClick="ViewComments_Click" CommandArgument= "<%# Container.DataItemIndex %>" CommandName ="Remove"  />
                 </ItemTemplate>

                <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                </asp:TemplateField>
       </Columns>

        


    </asp:GridView>

    <br />

    <img src ="https://lh5.googleusercontent.com/t79_4O5aUVyW-QbfDe4Zy-YjmYklc-Jpxb4Y6XqdgHkASrEBeEl8k064jhznivU810Bep2pshvscy-l0p0OFNkabulsGfGvMzivHj7aO" />

    <%--this provides the items in the GridView from the SQL database --%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand=
     "SELECT AppTable.appID, AppTable.Name, AppTable.Description, AppTable.Organization, AppTable.[Platform(s)], AppTable.[Version(s)], [Rating] = (CASE WHEN AVG(appRating) < 1 OR AVG(appRating) IS NULL --OR appRating is NULL
					THEN 'N/A'
				  ELSE
					 CONVERT(VARCHAR(5), CAST(AVG(CAST(appRating AS DECIMAL(10,2))) AS DECIMAL(10,2)))
					END
					)
     FROM AppTable LEFT JOIN CommentsTable
     ON CommentsTable.appID = AppTable.appID    
     GROUP BY AppTable.appID, AppTable.Name, AppTable.Description, AppTable.Organization, AppTable.[Platform(s)], AppTable.[Version(s)], AppTable.appID">
    </asp:SqlDataSource>
    
</asp:Content>
