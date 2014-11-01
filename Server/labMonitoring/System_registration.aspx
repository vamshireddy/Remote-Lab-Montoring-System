<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System_registration.aspx.cs" Inherits="labMonitoring.WebForm1" %>

<!DOCTYPE html>
<script runat="server">

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <span class="auto-style1">Lab Computer Registration Page</span><br class="auto-style1" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Select Lab"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" Height="21px" Width="73px">
        </asp:DropDownList>
        <br />
        Select Computer<br />
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="MAC Address"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="164px"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Please check your fields" Visible="False"></asp:Label>
        <br />
    
    </div>
    </form>
</body>
</html>
