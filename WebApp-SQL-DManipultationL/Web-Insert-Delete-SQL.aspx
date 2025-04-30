<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="Web-Insert-Delete-SQL.aspx.cs" 
    Inherits="WebApp_SQL_DManipultationL.Web_Insert_Delete_SQL" 
    UnobtrusiveValidationMode="None"
    %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Data Manipulation Lenguage</title>
    <link rel="stylesheet" href="Web-Insert-Delete-SQL.css" type="text/css" />
</head>
<body>
    <h1>DATOS DEL PRODUCTO</h1>
        <form id="form1" runat="server">
        <div>
            <span>ID</span>
            <asp:TextBox ID="txtIdProduct" runat="server" CssClass="aspNetTextBox"></asp:TextBox>
        </div>
        <div>
            <span>Nombre</span>
            <asp:TextBox ID="txtProductName" runat="server" CssClass="aspNetTextBox"></asp:TextBox>
        </div>
        <div>
            <span>A la venta</span>
            <asp:CheckBox ID="cbSuspendido" runat="server" />
        </div>
        <asp:Button runat="server" ID="btnSend" Text="Enviar" CssClass="aspNetButton" OnClick="btnSend_Click" />
        <br />
        <asp:Label runat="server" ID="lblQueryShow"></asp:Label>    
    </form>
    
    <%-- TODO: ASPX.CS , AGREGAR PRODUCTO A LA BASE DE DATOS --%>
</body>
</html>
