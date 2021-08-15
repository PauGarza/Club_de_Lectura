using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Club_de_Lectura
{
    public partial class PerfilU1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"] == null || Session["nombre"] == null)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("UsuarioLogin.aspx");
            }
            Label1.Text = Session["correo"].ToString();
            if (!(TextBox4.Text.Length>0 || TextBox5.Text.Length > 0 || TextBox6.Text.Length > 0))
            {
                String query = "select nombre, telefono, direccion from Usuario where claveU = ?";
                ConexionBD objetoConexion = new ConexionBD();
                OdbcConnection con = objetoConexion.conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("claveU", Session["clave"]);
                OdbcDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    LC.Text = Session["correo"].ToString();
                    TextBox4.Text = lector.GetValue(0).ToString();
                    TextBox5.Text = lector.GetValue(1).ToString();
                    TextBox6.Text = lector.GetValue(2).ToString();
                }
                con.Close();
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("UsuarioLogin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerfilU.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int rowsA = -3;
            String psw = TextBox2.Text.ToString();
            String conf = TextBox3.Text.ToString();
            String nom;
            String tel = TextBox5.Text.ToString();
            String dir = TextBox6.Text.ToString();
            String CU = Session["clave"].ToString();
            if (TextBox4.Text.Length > 0)
            {
                nom = TextBox4.Text.ToString();
            }
            else
            {
                nom = Session["nombre"].ToString();
            }
            String corr = Session["correo"].ToString();

            if (psw.Length == 0 && conf.Length == 0)
            {
                try
                {
                    String query = "UPDATE usuario SET nombre = ?, telefono = ?, direccion = ? WHERE claveU= ?";

                    ConexionBD objetoConexion = new ConexionBD();
                    OdbcConnection con = objetoConexion.conexion;
                    OdbcCommand comando = new OdbcCommand(query, con);
                    comando.Parameters.AddWithValue("nombre", nom);
                    comando.Parameters.AddWithValue("telefono", tel);
                    comando.Parameters.AddWithValue("direccion", corr);
                    comando.Parameters.AddWithValue("claveU", CU);
                    rowsA = comando.ExecuteNonQuery();
                    con.Close();
                    if (rowsA > 0)
                    {
                        //Response.Redirect("InicioUsuario.aspx");
                        Label2.Text = "Su perfil ha sido actualizado";

                    }
                    else
                    {
                        Label2.Text = "No actualizado";
                    }
                }
                catch (Exception ex)
                {
                    Label2.Text = "" + ex;
                }
            }
            else if (psw.Length > 0 || conf.Length > 0)
            {
                if (psw == conf)
                {

                    try
                    {
                        String query = "UPDATE usuario SET nombre = ?, contraseña = ?, telefono = ?, direccion = ? WHERE claveU= ?";

                        ConexionBD objetoConexion = new ConexionBD();
                        OdbcConnection con = objetoConexion.conexion;
                        OdbcCommand comando = new OdbcCommand(query, con);
                        comando.Parameters.AddWithValue("nombre", nom);
                        comando.Parameters.AddWithValue("contraseña", psw);
                        comando.Parameters.AddWithValue("telefono", tel);
                        comando.Parameters.AddWithValue("direccion", dir);
                        comando.Parameters.AddWithValue("claveU", CU);
                        rowsA = comando.ExecuteNonQuery();
                        con.Close();
                        if (rowsA > 0)
                        {
                            //Response.Redirect("InicioUsuario.aspx");
                            Label2.Text = "Su perfil ha sido actualizado";
                        }
                        else
                        {
                            Label2.Text = "No actualizado";
                        }
                    }
                    catch (Exception ex)
                    {
                        Label2.Text = "" + ex;
                    }
                }
                else
                {
                    Label2.Text = "Las contraseñas no coinciden";
                    psw = null;
                    nom = null;
                    TextBox2.Text = null;
                    TextBox3.Text = null;
                    Response.Redirect("PerfilU.aspx");

                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioUsuario.aspx");
        }

    }
}