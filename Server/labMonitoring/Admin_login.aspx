<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_login.aspx.cs" Inherits="labMonitoring.admin_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Password1 {
            width: 213px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>
    
        <asp:Label ID="Label1" runat="server" Text="Admin Login"></asp:Label>
    
        </h1>
        <p>
    
            Username</p>
    
    </div>
        <p>
            <asp:TextBox ID="un" runat="server" Width="209px" Height="22px"></asp:TextBox>
        </p>
        <p>
            Password</p>
        <p>
            <asp:TextBox ID="pass" runat="server" Height="21px" TextMode="Password" OnTextChanged="TextBox1_TextChanged" Width="208px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Submit" Width="188px" OnClick="Button1_Click" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Please check your username or password" ForeColor="Red"></asp:Label>
        </p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="un" Display="Dynamic" ErrorMessage="UserName is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pass" Display="Dynamic" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
    </form>
</body>
</html>
