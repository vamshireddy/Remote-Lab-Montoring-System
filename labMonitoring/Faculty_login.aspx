<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Faculty_login.aspx.cs" Inherits="labMonitoring.Faculty_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin-left: 160px">
    <form id="form1" runat="server">
    <div style="margin-left: 280px">
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="20pt" ForeColor="Blue" Text="Faculty Login"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Size="16pt" Text="Username: "></asp:Label>
        <br />
        <asp:TextBox ID="username_faculty" runat="server" Height="26px" Width="218px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Size="16pt" Text="Password"></asp:Label>
        <br />
        <asp:TextBox ID="pass_faculty" runat="server" Height="25px" TextMode="Password" Width="217px"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Font-Size="16pt" Height="44px" OnClick="Button1_Click" Text="Submit" Width="125px" />
        <br />
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="username_faculty" Display="Dynamic" ErrorMessage="Username is required!" Font-Size="16pt" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="pass_faculty" Display="Dynamic" ErrorMessage="Password is Required!" Font-Size="16pt" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    
    </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
