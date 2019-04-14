<%@ Page Title="App Comments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppComments.aspx.cs" Inherits="Appgregate.AppComments" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- I build this class to provide a Grid/Table of all comments for a given app. It loads based on the app 
        selected from the view comments button
        --%>

    <br />
    <br />
   <%--- 
       This code block only allows people who are logged in 
       to submit a comment. Regular non-users can only view comments
       ---%>

  <%  if (Context.User.IsInRole("Moderator") || Context.User.IsInRole("Admin")|| Context.User.IsInRole("User")) {%> 
  <asp:TextBox ID="txtComment" runat="server" Rows="5" Columns="20" TextMode="MultiLine" Width="400px" Text="Feel Free To Leave a Comment" style="resize:none" />  
  Rating
  <asp:DropDownList ID ="ratingDrop" runat="server" >
      <%---1 - 5 star ratings with the option of no comment  ---%>
        <asp:ListItem Selected ="True" Value="No Rating" >No Rating</asp:ListItem>
        <asp:ListItem Value="1" >1</asp:ListItem>
        <asp:ListItem Value="2" >2</asp:ListItem>
        <asp:ListItem Value="3" >3</asp:ListItem>
        <asp:ListItem Value="4" >4</asp:ListItem>
        <asp:ListItem Value="5" >5</asp:ListItem>
  </asp:DropDownList>

    <br />
    <asp:Button ID="SubmitComment" CssClass = "Button"  runat="server"   Text="Submit"  OnClick="SubmitButton_Click" />
    <%} %>
        <br />
        <br />
        <ul class ="commentGridview" >
        <asp:GridView ID="GridView" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" runat="server" DataKeyNames="username, commentText, appRating"  OnRowDataBound="Mygrid_RowDataBound"  OnRowCommand ="GridView1_RowCommand" >
            <Columns>
            <%-- Comments Gridview displays the user who submitted the comment, the text of that comment, and the appRating
                --%>
            <asp:BoundField DataField="username" HeaderText="Name" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" SortExpression="username" ></asp:BoundField>
            <asp:BoundField DataField="commentText" HeaderText="Comment" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" SortExpression="commentText" ></asp:BoundField>
            <asp:BoundField DataField="appRating" HeaderText="Rating" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" SortExpression="appRating" >
            </asp:BoundField>
            <%-- %><asp:BoundField DataField="Rating"     HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderText="Rating" ItemStyle-Width="10%" SortExpression="Rating" ></asp:BoundField> --%>
             <asp:TemplateField HeaderText="Remove"  HeaderStyle-CssClass="text-center"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30%">
                 <ItemTemplate>
                    
                <asp:LinkButton ID="RemoveButton" CssClass = "Button"  runat="server"   Text="Remove"  OnClick="DenyButton_Click" CommandArgument= "<%# Container.DataItemIndex %>" CommandName ="Remove"  />
           
                 </ItemTemplate>
             </asp:TemplateField>
   
           </Columns>
            
            
        

        
    </asp:GridView>
            </ul>
    <%--this provides the items in the GridView from the SQL database --%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [username], [commentText], [appRating] = (CASE WHEN CommentsTable.appRating = -1 THEN 'N/A' ELSE  CONVERT(VARCHAR(1), appRating) END)  FROM [CommentsTable] WHERE appID = @appID">
        <SelectParameters>
		    <asp:sessionparameter name="appID" sessionfield="appID" type="Int32" />
	    </SelectParameters>
    </asp:SqlDataSource>
    
</asp:Content>