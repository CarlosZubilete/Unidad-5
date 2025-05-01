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
      int counter = 1;
      using (SqlConnection connection = new SqlConnection(connectingString))
      {
        connection.Open();
        using (SqlCommand command = new SqlCommand(queryTable, connection))
        {
          using(SqlDataReader dataReader = command.ExecuteReader())
          {
            // aqui -> ddlToProvince.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
            while (dataReader.Read())
            {
              ListItem item = new ListItem();
              item.Text = counter.ToString() + " - " + dataReader[nameTable].ToString(); 
              item.Value = dataReader[idTable].ToString();   
              ddl.Items.Add(item);
              counter++;
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
      ddlProveedores.SelectedIndex = 0;
      ddlCategory.SelectedIndex = 0;
      // Reinicio los controles Drop down list box;
    }


    protected void btnSend_Click(object sender, EventArgs e)
    {
      // INSERT INTO Productos (IdProducto,NombreProducto, [] , []  ,Suspendido) VALUES (100,'Producto 100',0);
      byte valueSuspendido = cbSuspendido.Checked ? (byte)0 : (byte)1;
      int valueIdproducto = Convert.ToInt32(txtIdProduct.Text);
      string valueNameProcucto  = txtProductName.Text;

      string insert = "INSERT INTO Productos (IdProducto,NombreProducto" ; 
      string queryInserInto = "( " + valueIdproducto + ", '" + valueNameProcucto + "'";
       

      string opcionales = "";
  
      if (ddlProveedores.SelectedValue != "0")
      {
        //int idProveedor = Convert.ToInt32(ddlCategory.SelectedValue); 
        queryInserInto += Convert.ToInt32(ddlProveedores.SelectedValue);
        opcionales += ",IdProveedor"; 
      }
      
      if(ddlCategory.SelectedValue != "0")
      {
        if (opcionales.Length > 0)
        {
          queryInserInto += ", " + Convert.ToInt32(ddlProveedores.SelectedValue) + ", "+  Convert.ToInt32(ddlCategory.SelectedValue) ;
        }

        queryInserInto += ", " +  Convert.ToInt32(ddlCategory.SelectedValue);
        opcionales += ",IdCategoría"; 
      }


      // insert += opcionales + " ,Suspendido) VALUES" + queryInserInto + valueSuspendido;
      queryInserInto += ", " + valueSuspendido + ")";  
      // lblQueryShow.Text = insert + opcionales + " ,Suspendido) VALUES"; //

      insert += opcionales + " ,Suspendido) VALUES" + queryInserInto; 
      // Enviamos los datos ... 
    
      try
      {
        if (this.sendData(insert) == 1)
        {
          // codigo indicativo que salio todo bien.
          this.cleanControls();
          lblQueryShow.Text = insert.ToString();
        }
      }
      catch
      {
        lblQueryShow.Text = "Ocrurrió un error";
      } 
    }
  }
}