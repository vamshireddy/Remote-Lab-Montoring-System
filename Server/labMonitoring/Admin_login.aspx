<%@ Page Language="C#"  Theme = "Button_theme" AutoEventWireup="true" CodeBehind="Admin_login.aspx.cs" Inherits="labMonitoring.admin_login" MasterPageFile="~/design.Master"%>


<asp:Content ID="myContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        #Password1 {
            width: 213px;
        }
    </style>
        <asp:Panel runat="server" ID="pan">
            <div style="margin-left: 371px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="20pt" ForeColor="Blue" style="position: relative" Text="Please Login to continue"></asp:Label>
                <p style="margin-left: 160px">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="15pt" ForeColor="#3366FF" Text="Username"></asp:Label>
                </p>
                <p style="margin-left: 160px">
                    <asp:TextBox ID="un" runat="server" Height="51px" Width="320px"></asp:TextBox>
                </p>
                <p style="margin-left: 160px">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="15pt" ForeColor="#3366FF" Text="Password"></asp:Label>
                </p>
                <p style="margin-left: 160px">
                    <asp:TextBox ID="pass" runat="server" Height="52px" OnTextChanged="TextBox1_TextChanged" TextMode="Password" Width="321px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                </p>
                <p style="margin-left: 160px">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Height="61px" OnClick="Button1_Click" Text="Submit" Width="211px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </p>
                <p style="margin-left: 160px; height: 39px; width: 306px;">
                   
                    <asp:Label Font-Names="Century Gothic" ID="Label2" runat="server" Font-Size="20pt"  SkinID="aa" ForeColor="Red" Text="Please check your username or password"></asp:Label>
                </p>
                <div style="margin-left: 163px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="un" Display="Dynamic" ErrorMessage="UserName is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pass" Display="Dynamic" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
                    </div>
            </div>
        </asp:Panel>
</asp:Content>
