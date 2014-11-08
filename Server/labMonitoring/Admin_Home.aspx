<%@ Page Language="C#"  Theme = "Button_theme" AutoEventWireup="true" CodeBehind="Admin_Home.aspx.cs" Inherits="labMonitoring.WebForm3" MasterPageFile="~/design.Master"%>

 <asp:Content ID="myContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 560px"> 
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add a new Computer" Width="246px" Font-Size="15pt" Height="65px" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Modify a Computer"  Font-Size="15pt" Width="240px" Height="68px" OnClick="Button2_Click" />
    </div>   
 </asp:Content>