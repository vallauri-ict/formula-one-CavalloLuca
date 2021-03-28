<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormulaOneWebForm.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> FormulaOne- WebForm</title>
</head>
<body>
    <form id="form1" runat="server" >
        <div>
            <!--
            userName <asp:TextBox ID="txtUserName" runat="server" /> <br />
            Password <input type="text" ID="txtPassword"/> <br />
            -->
            <asp:DropDownList ID="cmbTables" runat="server" OnSelectedIndexChanged="changeSelection" AutoPostBack="true">
                
            </asp:DropDownList>
            
        </div>
        <br />
        <div>
            <asp:DataGrid ID="dgvItems" runat="server"></asp:DataGrid>
        </div>
        <br />
        <div>
            <asp:DataGrid ID="lblNazioni" runat="server"></asp:DataGrid>
        </div>
    </form>
</body>
</html>
<!-- IIS: internet information services-->
