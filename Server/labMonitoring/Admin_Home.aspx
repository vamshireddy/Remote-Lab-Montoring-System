<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Home.aspx.cs" Inherits="labMonitoring.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="header" runat="server" Text="Select your choice"></asp:Label>
        <br />
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add a new Computer" Width="177px" />
        <br />
    
    </div>
        <asp:Button ID="Button2" runat="server" Text="Modify a Computer" Width="180px" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Delete Computer" Width="178px" />
    </form>
</body>
</html>
