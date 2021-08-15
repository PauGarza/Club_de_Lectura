using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Club_de_Lectura
{
    public partial class LoginAdmin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String c = TextBox1.Text.ToString();
            String contra = TextBox2.Text.ToString();
            OdbcConnection con = new ConexionBD().conexion;
            String query = "select nombre from Administrador where cAdmin = ? and contraseña = ?";
            OdbcCommand comando = new OdbcCommand(query, con);
            comando.Parameters.AddWithValue("cAdmin", c);
            comando.Parameters.AddWithValue("contraseña", contra);

            OdbcDataReader lector = comando.ExecuteReader();

            if (lector.HasRows == true)
            {
                lector.Read();
                String nombre = lector.GetString(0);
                Session["nombreA"] = nombre;
                Session["claveA"] = c;
                Session.Timeout = 10;
                Label1.Text = "" + c + " " + nombre;
                Response.Redirect("InicioAdmin.aspx");
            }
            else
            {
                Label1.Text = "Las credenciales no coinciden";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioLogin.aspx");
        }
    }
}