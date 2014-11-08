<%@ Page Language="C#" Theme="Button_theme" AutoEventWireup="true" MasterPageFile="~/design.Master" CodeBehind="System_registration.aspx.cs" Inherits="labMonitoring.WebForm1" %>

<asp:Content ID="myContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel DefaultButton="Button1" runat="server">
            <div style="margin-left: 593px; width: 416px; height: 314px;">
        <asp:Label Font-Size="20px" ID="Label1" runat="server" Text="Select Lab"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" Height="21px" Width="73px"></asp:DropDownList>
        <br />
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label Font-Size="20px" ID="Label2" runat="server" Text="MAC Address"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="32px" Width="168px"></asp:TextBox>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TextBox1" runat="server" ValidationExpression="^[0-9A-F]{12}$" ErrorMessage="Invalid MAC address"></asp:RegularExpressionValidator>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" Height="48px" Width="156px" />
        <br />
        <asp:Label Font-Size="20px" ID="Label3" runat="server" Text="Please check your fields" Visible="False"></asp:Label>
        <br />
                </div>
        </asp:Panel>
</asp:Content>
