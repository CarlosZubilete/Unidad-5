using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

// TODO: Al agregarse un producto nuevo , El control de ddlProductos no se actualiza.
// TODO: Limpiar el mensaje de exito o error una vez que el usuario ingresa
//      un valor en los controles Lables (agregado y eliminado)


namespace WebApp_SQL_DManipultationL
{
  public partial class Web_Insert_Delete_SQL : System.Web.UI.Page
  {
    // private const string connectingString = @"Data Source=DESKTOP-LFTFVP5\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True";

    private string queryProveedores = @"Select * From Proveedores";
    private string queryCategorias = @"Select * From Categorías";
    private string quetyProducts = @"Select * from Productos";

    // Intanciamos la clase Servicio:
    private ServiceProduct service = new ServiceProduct(); 
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        // IdProveedor , NombreCompañía 
        service.downloadingData(ddlProveedores, queryProveedores, "IdProveedor", "NombreCompañía");
        //IdCategoría , NombreCategoría 
        service.downloadingData(ddlCategory, queryCategorias, "IdCategoría", "NombreCategoría");
        // IdProducto , NombreProducto:
        service.downloadingData(ddlProducts, quetyProducts, "IdProducto", "NombreProducto");
      }
    }

    private void cleanControls()
    {
      txtIdProduct.Text = string.Empty;
      txtProductName.Text = string.Empty;
      ddlProveedores.SelectedIndex = 0;
      ddlCategory.SelectedIndex = 0;
      cbSuspendido.Checked = false;
    }

    private string getQueryAddProduct()
    {
      // Campos obligatorios: 
      // INSERT INTO Productos (IdProducto,NombreProducto, [] , []  ,Suspendido)
      // VALUES (100,'Producto 100',0);
      byte valueSuspendido = cbSuspendido.Checked ? (byte)0 : (byte)1;
      int valueIdproducto = Convert.ToInt32(txtIdProduct.Text);
      string valueNameProcucto = txtProductName.Text;

      string fields = "INSERT INTO Productos (IdProducto,NombreProducto";
      string values = "( " + valueIdproducto + ", '" + valueNameProcucto + "'";

      if (ddlProveedores.SelectedValue != "0")
      {
        values += ", " + Convert.ToInt32(ddlProveedores.SelectedValue);
        fields += ",IdProveedor";
      }

      if (ddlCategory.SelectedValue != "0")
      {
        values += ", " + Convert.ToInt32(ddlCategory.SelectedValue);
        fields += ",IdCategoría";
      }

      fields += " ,Suspendido) VALUES";
      values += ", " + valueSuspendido + ")";
      string query = fields + values;
      return query; 
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {      
      string query = getQueryAddProduct(); 
      // Enviamos los datos ... 
      try
      {
        if (service.executeNonQuery(query) == 1)
        {
          this.cleanControls();
          lblQueryShow.Text = query.ToString();
        }
      }
      catch
      {
        lblQueryShow.Text = "Ocrurrió un error";
      } 
    }
 
    protected void btnDelete_Click(object sender, EventArgs e)
    {
      // ChekOut , esto es posbile porque validamos previamente
      int idProduct = Convert.ToInt32(ddlProducts.SelectedValue); 
      string query = "Delete from Productos Where IdProducto =" + idProduct;
      try
      {
        if(service.executeNonQuery(query) == 1)
        {
          lblShowProduct.Text = "Eliminacion exitosa";
          ddlProducts.SelectedIndex = 0; 
        }
      }
      catch
      {
        lblShowProduct.Text = "Ocurrió un error";
      }
    }
  }
}