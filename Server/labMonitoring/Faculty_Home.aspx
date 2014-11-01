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
        <br />
        Select the LAB:<br />
        <asp:DropDownList ID="DropDownList1" runat="server" Height="21px" Width="154px">
        </asp:DropDownList>
        <br />
        <br />
        Select the Computer<br />
        <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="156px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Height="26px" OnClick="Button1_Click" Text="Submit" Width="74px" />
    
    </div>
    </form>
</body>
</html>
