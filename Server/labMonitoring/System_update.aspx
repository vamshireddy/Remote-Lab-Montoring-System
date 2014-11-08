<%@ Page Language="C#" Theme="Button_theme" MasterPageFile="~/design.Master" AutoEventWireup="true" CodeBehind="System_update.aspx.cs" Inherits="labMonitoring.System_update" %>

<asp:Content ID="myContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="height: 313px; width: 765px">
     <asp:Label runat="server" Font-Size="40px" ID="aa" Text="Update the details"/> <br />
<asp:GridView Font-Size="25px" ID="GridView1" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
    DataKeyNames="computerID" OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added." Height="246px" Width="765px">
    <Columns>
        <asp:BoundField DataField="computerID" HeaderText="Computer" ItemStyle-Width="150" />
        <asp:BoundField DataField="MAC" HeaderText="MAC" ItemStyle-Width="150" />
        <asp:BoundField DataField="labID" HeaderText="Lab" ItemStyle-Width="150" />
        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
            ItemStyle-Width="100" />
    </Columns>
</asp:GridView>
<table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse; height: 66px; width: 763px;">
    <tr>
        <td class="auto-style1">
            ComputerID:<br />
            <asp:TextBox ID="pctxt" runat="server" Width="140"  />
        </td>
        <td style="width: 150px">
            MAC:<br />
            <asp:TextBox ID="mactxt" runat="server" Width="140" />
        </td>
        <td style="width: 150px">
            LabID:<br />
            <asp:TextBox ID="labtxt" runat="server" Width="140" />
        </td>
        <td style="width: 100px">
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" />
        </td>
    </tr>
</table>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conn_str %>"
    SelectCommand="SELECT * FROM Computer"
    InsertCommand="INSERT INTO Computer VALUES (@computerID, @MAC, @labID)"
    UpdateCommand="UPDATE Computer SET computerID = @computerID, MAC = @MAC, labID = @labID WHERE computerID = @computerID and  MAC = @MAC"
    DeleteCommand="DELETE FROM Computer WHERE computerID = @computerID and MAC = @MAC" >
    <InsertParameters>
        <asp:ControlParameter Name="computerID" ControlID="pctxt" Type="String" />
        <asp:ControlParameter Name="MAC" ControlID="mactxt" Type="String" />
        <asp:ControlParameter Name="labID" ControlID="labtxt" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="computerID" Type="String" />
        <asp:Parameter Name="MAC" Type="String" />
        <asp:Parameter Name="labID" Type="String" />
    </UpdateParameters>
    <DeleteParameters>
        <asp:Parameter Name="computerID" Type="String" />
        <asp:Parameter Name="MAC" Type="String" />
    </DeleteParameters>
</asp:SqlDataSource>
    </div>
    </asp:Content>