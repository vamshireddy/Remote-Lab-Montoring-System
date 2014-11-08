<%@ Page Language="C#" Theme="Button_theme" AutoEventWireup="true" CodeBehind="Faculty_Home.aspx.cs" Inherits="labMonitoring.Faculty_Home" MasterPageFile="~/design.Master"%>

 <asp:Content ID="myContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel runat="server" DefaultButton="Button1">
        <div style="width: 542px; margin-left: 554px">
            <br />
        <asp:Label ID="Label2" runat="server" Font-Size="30pt" Text="Select a LAB"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" Height="47px" Width="312px" Font-Size="20pt"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Font-Size="30pt" Text="Select a Computer"></asp:Label><br />
        <asp:DropDownList ID="DropDownList2" runat="server" Height="50px" Width="312px" Font-Size="20pt">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Size="20pt" Text="There are no computers logged into the system"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Height="59px" OnClick="Button1_Click" Text="Submit" Width="311px" Font-Size="20pt" />
        </div>
        </asp:Panel> 
</asp:Content>