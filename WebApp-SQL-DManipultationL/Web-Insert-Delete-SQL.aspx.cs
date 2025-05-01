using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace WebApp_SQL_DManipultationL
{
  public partial class Web_Insert_Delete_SQL : System.Web.UI.Page
  {
    private const string connectingString = @"Data Source=DESKTOP-LFTFVP5\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True";

    private string queryProveedores = @"Select * From Proveedores";
    private string queryCategorias = @"Select * From Categorías";
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {

        // IdProveedor , NombreCompañía 
        this.downloadingData(ddlProveedores, queryProveedores, "IdProveedor", "NombreCompañía");
        //IdCategoría , NombreCategoría 
        this.downloadingData(ddlCategory ,queryCategorias, "IdCategoría", "NombreCategoría");
      }
    }

    // Agreamos informacion al al Drop List Items:
    private void downloadingData( DropDownList ddl,string queryTable,string idTable, string nameTable )
    {
      using (SqlConnection connection = new SqlConnection(connectingString))
      {
        connection.Open();
        using (SqlCommand command = new SqlCommand(queryTable, connection))
        {
          using(SqlDataReader dataReader = command.ExecuteReader())
          {
            while (dataReader.Read())
            {
              ddl.Items.Add(dataReader[idTable] + " - " + dataReader[nameTable]);
            }
          }
        }
      }
    }

    // Agramos una funcion para enviar los datos ingresado a la base SQL
    private int sendData(string query)
    {
      using (SqlConnection connection = new SqlConnection(connectingString))
      using (SqlCommand command = new SqlCommand(query, connection))
      {
        connection.Open();
        return command.ExecuteNonQuery();
      }
    }

    private void cleanControls()
    {
      txtIdProduct.Text = string.Empty;
      txtProductName.Text = string.Empty;
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
      // INSERT INTO Productos (IdProducto,NombreProducto,Suspendido) VALUES (100,'Producto 100',0);

      byte valueSuspendido = cbSuspendido.Checked ? (byte)1 : (byte)0;
      int valueIdproducto = Convert.ToInt32(txtIdProduct.Text);
      string valueNameProcucto  = txtProductName.Text;

      string insert = "INSERT INTO Productos (IdProducto,NombreProducto,Suspendido) VALUES "; 

      string queryInserInto = insert + "( " + valueIdproducto + ", '" + valueNameProcucto + "', " + valueSuspendido + " )";
      // Enviamos los datos ... 
      if (this.sendData(queryInserInto) == 1)
      {
        // codigo indicativo que salio todo bien.
        this.cleanControls();
      }

      // cartel aclaratorio para ver las consultas
      lblQueryShow.Text = insert + "( " + valueIdproducto.ToString() + ", '"+ valueNameProcucto +"', "+ valueSuspendido + " )";

    }
  }
}