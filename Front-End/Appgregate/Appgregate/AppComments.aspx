<%@ Page Title="App Comments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppComments.aspx.cs" Inherits="Appgregate.AppComments" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- I build this class to provide a Grid/Table of all apps presents. Apps are loaded in from a dummy/future working database 
         stored under "App Data" called "AppList". The view comments button needs to be adjusted to link to custom Comments pages.
        
        --%>

    <br />
    <br />
    
  <asp:TextBox ID="txtComment" runat="server" Rows="5" Columns="20" TextMode="MultiLine" Width="400px" Text="Feel Free To Leave a Comment" style="resize:none" />  
  Rating
  <asp:DropDownList ID ="ratingDrop" runat="server" >
        <asp:ListItem Selected ="True" Value="No Rating" >No Rating</asp:ListItem>
        <asp:ListItem Value="1" >1</asp:ListItem>
        <asp:ListItem Value="2" >2</asp:ListItem>
        <asp:ListItem Value="3" >3</asp:ListItem>
        <asp:ListItem Value="4" >4</asp:ListItem>
        <asp:ListItem Value="5" >5</asp:ListItem>
  </asp:DropDownList>
    <br />
    <asp:Button ID="SubmitComment" CssClass = "Button"  runat="server"   Text="Submit"  OnClick="SubmitButton_Click" />
        <br />
        <br />
        <asp:GridView ID="GridView" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" runat="server" DataKeyNames="username, commentText, appRating">
            <Columns>
            <%-- Our Gridview accounts for Name, Description, Organization, Platform, Versions, Rating, and Comments/
                 All data and headers are centered, and space is provided appropriately for the content of each column.
                --%>
            <asp:BoundField DataField="username" HeaderText="Name" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" SortExpression="username" ></asp:BoundField>
            <asp:BoundField DataField="commentText" HeaderText="Comment" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" SortExpression="commentText" ></asp:BoundField>
            <asp:BoundField DataField="appRating" HeaderText="Rating" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" SortExpression="appRating" ></asp:BoundField>
            <%-- %><asp:BoundField DataField="Rating"     HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderText="Rating" ItemStyle-Width="10%" SortExpression="Rating" ></asp:BoundField> --%>
             <asp:TemplateField HeaderText="Remove"  HeaderStyle-CssClass="text-center"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30%">
                 <ItemTemplate>
                      <asp:LinkButton ID="RemoveButton" CssClass = "Button"  runat="server"   Text="Deny"  OnClick="DenyButton_Click" CommandArgument= "<%# Container.DataItemIndex %>" CommandName ="Remove"  />
                 </ItemTemplate>
             </asp:TemplateField>
           </Columns>
            
        

        
    </asp:GridView>
    <%--this provides the items in the GridView from the SQL database --%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [username], [commentText], [appRating] FROM [CommentsTable]"></asp:SqlDataSource>
    
</asp:Content>