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
    protected void Page_Load(object sender, EventArgs e)
    {
      // todo! Obtener los id de los provedores y categorias:
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
      // INSERT INTO Productos (IdProducto,NombreProducto,Suspendido)
      // VALUES (100,'Producto 100',0);
      // TODO ESTOS VALORES SON NECESARIOS , NO ADMITEN NULL
      string insert = "INSERT INTO Productos ( "; 
      int valueIdproducto = -1;
      string valueNameProcucto  = "";
     
      

      if (txtIdProduct.Text.Trim().Length > 0)
      {
        insert += "IdProducto ";
        valueIdproducto = Convert.ToInt32(txtIdProduct.Text);
      }

      if ( txtProductName.Text.Trim().Length > 0)
      {
        insert += " , NombreProducto";
        valueNameProcucto = " '" + txtProductName.Text +"' "; 
      }

      // TODO ESTOS VALORES SON NECESARIOS , NO ADMITEN NULL
      // (false) esta a la venta, 1(verdadero)suspendido
      byte valueSuspendido = cbSuspendido.Checked ? (byte)1 : (byte)0;
      if (cbSuspendido.Checked)
      {
       
        insert += ", Suspendido) VALUES ";
      }
      else
      {
        insert += ") VALUES ";
      }

      // cartel aclaratorio para ver las consultas
      lblQueryShow.Text = insert + "( " + valueIdproducto.ToString() + ", "  + valueNameProcucto + ", "+ valueSuspendido + " )";
      // 
  
      string queryInserInto = insert + "( " + valueIdproducto + ", " + valueNameProcucto + ", " + valueSuspendido + " )";
      // Enviamos los datos ... 
      if (this.sendData(queryInserInto) == 1)
      {
        // codigo indicativo que salio todo bien.
        this.cleanControls();
      }

 
    }
  }
}