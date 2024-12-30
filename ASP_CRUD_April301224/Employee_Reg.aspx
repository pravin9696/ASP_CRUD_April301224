<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee_Reg.aspx.cs" Inherits="ASP_CRUD_April301224.Employee_Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Employee Registration Form</h2>
            <table>
                <tr><td>Employee ID</td><td><asp:TextBox ID="txtEmpID" runat="server"></asp:TextBox></td></tr>
                 <tr><td>Employee Name</td><td><asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox></td></tr>
                 <tr><td>Contact No.</td><td><asp:TextBox ID="txtContact" runat="server"></asp:TextBox></td></tr>
                 <tr><td>City</td><td>
                     <asp:DropDownList ID="dropCity" runat="server" DataSourceID="SqlDataSource2" DataTextField="CityName" DataValueField="CityName">
                       
                     </asp:DropDownList>
                     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:EmpDB4AprilConnectionString %>" ProviderName="<%$ ConnectionStrings:EmpDB4AprilConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [tblCity]"></asp:SqlDataSource>
                     </td></tr>
                 <tr><td colspan="2">
                     <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btnUpdate" runat="server" Enabled="False" OnClick="btnUpdate_Click" Text="Update" />
                     </td></tr>

            </table>
        </div>
    </form>
</body>
</html>
