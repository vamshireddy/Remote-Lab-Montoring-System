<%@ Page Language="C#" Theme="Button_theme" AutoEventWireup="true" CodeBehind="Faculty_login.aspx.cs" Inherits="labMonitoring.Faculty_login" MasterPageFile="~/design.Master"%>

 <asp:Content ID="myContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel CssClass="panelclass" runat="server" ID="panel1" DefaultButton="Button1">
        <div style="left: 558px; position: relative; top: 0px; width: 476px;">
            <br />
            <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="20pt" ForeColor="Blue" Text="Faculty Login" style="position: relative"></asp:Label>
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
        <asp:Button ID="Button1" runat="server" Font-Size="16pt" Height="53px" OnClick="Button1_Click" Text="Submit" Width="176px" />
        <br />
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="username_faculty" Display="Dynamic" ErrorMessage="Username is required!" Font-Size="16pt" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="pass_faculty" Display="Dynamic" ErrorMessage="Password is Required!" Font-Size="16pt" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="20pt" ForeColor="Red" Text="Invalid Login Details"></asp:Label>
        </div>
        </asp:Panel>
</asp:Content>