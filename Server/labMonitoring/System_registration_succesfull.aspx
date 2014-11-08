<%@ Page Language="C#" Theme="Button_theme" AutoEventWireup="true" CodeBehind="System_registration_succesfull.aspx.cs" Inherits="labMonitoring.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Font-Size="20pt" Text="You have succesfully added your PC to the Database"></asp:Label>
        </div>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Go to Home" OnClick="Button1_Click" Height="49px" Width="163px" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Logout" Height="50px" Width="160px" />
    </form>
</body>
</html>
