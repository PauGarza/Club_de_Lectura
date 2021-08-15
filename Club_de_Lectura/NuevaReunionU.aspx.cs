using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Club_de_Lectura
{
    public partial class NuevaReunionU1 : System.Web.UI.Page
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
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://meet.google.com");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerfilU.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("UsuarioLogin.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String linkB = "https://meet.google.com/";
            String Fecha = TextBox3.Text;
            String Hora = TextBox4.Text;
            int Duracion = Int32.Parse(TextBox1.Text);
            String Link = TextBox2.Text;

            int idSala = Int32.Parse(Session["Sala"].ToString());
            int idR = 1;
            if (Fecha.Length==10 && Fecha.Substring(4,1).Equals("-") && Fecha.Substring(7, 1).Equals("-"))
            {
                if (Hora.Length == 5 && Hora.Substring(2, 1).Equals(":"))
                {
                    if (Link.Length>linkB.Length && Link.Substring(0,24).Equals(linkB))
                    {
                        Fecha = Fecha + " " + Hora;
                        String query = "select top(1) idReunion from Reunion order by idReunion desc";
                        OdbcConnection conID = new ConexionBD().conexion;
                        OdbcCommand comandoID = new OdbcCommand(query, conID);
                        OdbcDataReader lectorID = comandoID.ExecuteReader();
                        if (lectorID.HasRows)
                        {
                            lectorID.Read();
                            idR = Int32.Parse(lectorID.GetValue(0).ToString()) + 1;
                        }

                        query = "insert into Reunion values (?, ?, ?, ?, ?)";
                        OdbcConnection con = new ConexionBD().conexion;
                        OdbcCommand comando = new OdbcCommand(query, con);
                        comando.Parameters.AddWithValue("idReunion", idR);
                        comando.Parameters.AddWithValue("idSala", idSala);
                        comando.Parameters.AddWithValue("fechaR", Fecha);
                        comando.Parameters.AddWithValue("duracion", Duracion);
                        comando.Parameters.AddWithValue("linkR", Link);
                        comando.ExecuteNonQuery();
                        Label2.Text = "Reunion creada con exito";
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                        TextBox4.Text = "";
                    }
                    else
                    {
                        Label2.Text = "Formato de Link no valida "+Link.Substring(0,24);
                    }
                }
                else
                {
                    Label2.Text = "Formato de Hora no valida";
                }          
            }
            else
            {
                Label2.Text = "Formato de Fecha no valida";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisSalasU.aspx");
        }
    }
}