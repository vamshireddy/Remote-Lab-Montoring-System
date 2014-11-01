<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="labMonitoring.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <h1>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Lab Monitoring System" style="font-weight: 700" Font-Bold="True" Font-Italic="False" Font-Underline="False" ForeColor="#009933"></asp:Label>
        </h1>
        <p style="margin-left: 280px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Admin Login" Width="193px" ForeColor="#FF6600" Height="45px" />
        </p>
        <div style="margin-left: 280px">
            <br />
            <asp:Button ID="Button2" runat="server" Text="Faculty Login" Width="192px" ForeColor="#FF6600" Height="44px" OnClick="Button2_Click" />
            <br />
            <br />
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
