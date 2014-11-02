<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Faculty_Home.aspx.cs" Inherits="labMonitoring.Faculty_Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:Label ID="Label2" runat="server" Font-Size="30pt" Text="Select your LAB"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" Height="47px" Width="312px" Font-Size="20pt" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        <br />
        <br />
        Select the Computer<br />
        <asp:DropDownList ID="DropDownList2" runat="server" Height="50px" Width="312px" Font-Size="20pt">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Size="20pt" Text="There are no computers logged into the system"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Height="60px" OnClick="Button1_Click" Text="Submit" Width="130px" Font-Size="20pt" />
    
    </div>
    </form>
</body>
</html>
