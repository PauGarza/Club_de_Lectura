using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Club_de_Lectura
{
    public partial class NuevoUsuario1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String CU = "";
            String nom = TextBox2.Text;
            String c = TextBox3.Text;
            String p = TextBox4.Text;
            String pc = TextBox5.Text;
            String t = TextBox6.Text;
            String d = TextBox7.Text;
            if (nom.Length > 0 && c.Length > 0 && p.Length > 0 && pc.Length > 0 && t.Length > 0 && d.Length > 0)
            {
                if (nom.Length >= 5)
                {
                    int Nlng = nom.Length;
                    int Tlng = t.Length;
                    Random rand = new Random();
                    int vuelta = 0;
                    OdbcDataReader lec;
                    Boolean lineas = false;
                    do
                    {
                        vuelta++; String sp = nom.Substring(Nlng - 2, 2);
                        if (sp.Contains("ñ"))
                        {
                            CU = "" + nom.Substring(0, 2) + "oth" + t.Substring(Tlng - 2, 2) + vuelta;
                        }
                        else
                        {
                            CU = "" + nom.Substring(0, 2) + sp + t.Substring(Tlng - 2, 2) + vuelta;
                        }
                        String query = "select * from Usuario where claveU = ?";
                        OdbcConnection con = new ConexionBD().conexion;
                        OdbcCommand comando = new OdbcCommand(query, con);
                        comando.Parameters.AddWithValue("claveU", CU);
                        lec = comando.ExecuteReader();
                        lineas = lec.HasRows;
                        con.Close();
                    } while (lineas);

                    if (p.Equals(pc))
                    {
                        String query = "insert into Usuario values (?, ?, ?, ?, ?, ?)";

                        try
                        {
                            OdbcConnection con = new ConexionBD().conexion;
                            OdbcCommand comando = new OdbcCommand(query, con);
                            comando.Parameters.AddWithValue("claveU", CU);
                            comando.Parameters.AddWithValue("nombre", nom);
                            comando.Parameters.AddWithValue("correo", c);
                            comando.Parameters.AddWithValue("contraseña", p);
                            comando.Parameters.AddWithValue("telefono", t);
                            comando.Parameters.AddWithValue("direccion", d);
                            comando.ExecuteNonQuery();
                            Label1.Text = "CUENTA CREADA \n Tu Clave de acceso es: " + CU;
                            con.Close();

                        }
                        catch (Exception ex)
                        {
                            Label1.Text = "" + ex;
                        }
                        if (Label1.Text.Length > 0)
                        {
                            TextBox2.Text = "";
                            TextBox3.Text = "";
                            TextBox4.Text = "";
                            TextBox5.Text = "";
                            TextBox6.Text = "";
                            TextBox7.Text = "";
                        }
                    }
                    else
                    {
                        Label1.Text = "Las contraseñas no coinciden";
                    }
                }
                else
                {
                    Label1.Text = "Nombre muy corto, agrega tu segundo nombre o primer apellido";
                }
            }
            else
            {
                Label1.Text = "Algunos de los campos no fue completado";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioLogin.aspx");

        }
    }
}