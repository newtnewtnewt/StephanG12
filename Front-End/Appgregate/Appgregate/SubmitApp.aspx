<%@ Page Title="Submit App" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubmitApp.aspx.cs" Inherits="Appgregate.SubmitApp"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%-- 
        This class extablishes a page where the users will be able to input their requests using 
        the provided textboxes. Hitting the submit button will validate the input, and if the input is invalid it will display 
        preferably red text indicating that an error occurred with one of the data fields.
        A correct submission will be inserted into the database of requests.
        --%>
    <h2> App Submission Page</h2>
    <h3>Please fill in the following fields and hit Submit!</h3>
    <br />
    <p> Name </p>
    <asp:TextBox ID="Name" runat="server" ReadOnly="False" Width="175px" ></asp:TextBox>
    <br />
    <br />
    <p> Description </p>
    <asp:TextBox ID="Description" runat="server" ReadOnly="False" Width="175px" ></asp:TextBox>
    <br />
    <br />
    <p> Organization </p>
    <asp:TextBox ID="Organization" runat="server" ReadOnly="False" Width="175px" ></asp:TextBox>
    <br />
    <br />
    <p> Platform(s)</p>
    <asp:TextBox ID="Platform" runat="server" ReadOnly="False" Width="175px" ></asp:TextBox>
    <br />
    <br />
    <p> Version(s)</p>
    <asp:TextBox ID="Version" runat="server" ReadOnly="False" Width="175px" ></asp:TextBox>
    <br />
<%--<br />
    <p> Rating</p>
    <asp:TextBox ID="Rating" runat="server" ReadOnly="False" Width="175px" ></asp:TextBox>
    <br />--%>
    <br />
    <%-- This button's action is defined under SubmitApp.aspx.cs, the SQL functionality needs fleshed out --%>
    <asp:Button ID="SubmitButton" runat="server" Text="Submit"  OnClick="SubmitButton_Click" />  

</asp:Content>
