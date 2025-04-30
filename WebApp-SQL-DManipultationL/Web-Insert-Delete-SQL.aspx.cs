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

    protected void btnSend_Click(object sender, EventArgs e)
    {
      // INSERT INTO Productos (IdProducto,NombreProducto,Suspendido)
      // VALUES (100,'Producto 100',0);
      string insert = "INSERT INTO Productos ( "; 
      int valueIdproducto = -1;
      string valueNameProcucto  = "";
      Byte valueSuspendido = 1; 

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
       // (false) esta a la venta, 1(verdadero)suspendido
      if (cbSuspendido.Checked)
      {
        valueSuspendido = 0;
        insert += ", Suspendido) VALUES ";
      }
      else
      {
        insert += ") VALUES ";
      }

      lblQueryShow.Text = insert + "( " + valueIdproducto.ToString() + ", "  + valueNameProcucto + ", "+ valueSuspendido + " )";
      // 
      string queryInserInto;
      queryInserInto = insert + "( " + valueIdproducto + ", " + valueNameProcucto + ", " + valueSuspendido + " )";
      SqlConnection sqlConnection = new SqlConnection(connectingString);
      sqlConnection.Open();

      SqlCommand sqlCommand = new SqlCommand(queryInserInto, sqlConnection);
      sqlCommand.ExecuteNonQuery();

      sqlConnection.Close();
     
    }
  }
}