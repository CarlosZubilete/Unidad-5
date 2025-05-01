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
    <h1>Agregando un Producto Nuevo</h1>
        <form id="form1" runat="server">
            <%-- FORMULARIO PARA AGREGAR UN PRODUCTO --%>
        <div>
            <span>ID del producto</span>
            <asp:TextBox ID="txtIdProduct" runat="server" CssClass="aspNetTextBox" ValidationGroup="Add"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredID" runat="server" ControlToValidate="txtIdProduct" Font-Size="Small" ForeColor="#FF3300" Height="16px" Width="418px" ValidationGroup="Add">Este campo es requerido</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                runat="server" ControlToValidate="txtIdProduct" 
                Font-Size="Smaller" ForeColor="#FF3300" Width="421px" ValidationExpression="^[1-9][0-9]*$" ValidationGroup="Add">Solo Números enteros postivos</asp:RegularExpressionValidator>
        </div>
        <div>
            <span>Nombre del producto</span>
            <asp:TextBox ID="txtProductName" runat="server" CssClass="aspNetTextBox" ValidationGroup="Add"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredNameProduct" runat="server" ControlToValidate="txtProductName" Font-Size="Small" ForeColor="#FF3300" ValidationGroup="Add">Este campo es querido</asp:RequiredFieldValidator>
        </div>
        <div>
            <span>Proveedores:
            <asp:DropDownList ID="ddlProveedores" runat="server" ValidationGroup="Add">
                <asp:ListItem Value="0" Enabled="True">-- Seleccionar -- </asp:ListItem>
            </asp:DropDownList>
            </span>
        </div>
        <div>
            <span>Categorías:
            <asp:DropDownList ID="ddlCategory" runat="server" ValidationGroup="Add">
                <asp:ListItem Value="0" Enabled="True">-- Seleccionar -- </asp:ListItem>
            </asp:DropDownList>
            </span>
        </div>
        <div>
            <span>Indicar si está a la venta</span>
            <asp:CheckBox ID="cbSuspendido" runat="server" Text="Disponible" ValidationGroup="Add" />
        </div>
        <asp:Button runat="server" ID="btnSend" Text="Enviar" CssClass="aspNetButton" OnClick="btnSend_Click" ValidationGroup="Add" />
        <br />
        <asp:Label runat="server" ID="lblQueryShow"></asp:Label>    
            <%-- FIN : FORMULARIO PARA AGREGAR UN PRODUCTO --%>
            <hr />
            <%-- Formulario para eliminar un producto --%>
        <div>
            <h3>Elimar Producto:</h3>
            <div>
                <span>
                    Obtener producto 
                    <asp:DropDownList runat="server"  
                        ID="ddlProducts" AutoPostBack="false" ValidationGroup="Deleted">
                        <asp:ListItem Value="0" Enabled="True">-- Seleccionar -- </asp:ListItem>
                    </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlProducts" Font-Size="Small" ForeColor="#FF3300" 
                    InitialValue="0" ValidationGroup="Deleted">Debe seleccionar un item</asp:RequiredFieldValidator>
                </span>
            </div>
            <div>
                <%-- Mostramos el producto que eliminara --%>
                <asp:Button ID="btnDelete" runat="server" 
                    Text="Eliminar" ValidationGroup="Deleted" OnClick="btnDelete_Click" />
                <br />
                <asp:Label ID="lblShowProduct" runat="server"></asp:Label>
                
            </div>
        </div>
    </form>
</body>
</html>
