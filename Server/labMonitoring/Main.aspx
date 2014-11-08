<%@ Page Language="C#" Theme="Button_theme" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="labMonitoring.main" MasterPageFile="~/design.Master" %>

<asp:Content ID="myContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="position: relative; top: 79px; left: 564px; height: 207px; width: 216px">
        <h1>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Admin Login" Width="258px" ForeColor="#3366FF" Height="77px" Font-Bold="True" Font-Size="20pt" />
        </h1>
            <asp:Button ID="Button2" runat="server" Text="Faculty Login" Width="258px" ForeColor="#0066FF" Height="74px" OnClick="Button2_Click" Font-Bold="True" Font-Size="20pt" />
        </div>
</asp:Content>
