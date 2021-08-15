using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Club_de_Lectura
{
    public partial class CrearSalaU1 : System.Web.UI.Page
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
            if (!(DropDownList1.Items.Count>0))
            {
                String query = "select idT, nombre from Temas";
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                OdbcDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    DropDownList1.DataSource = lector;
                    DropDownList1.DataTextField = "nombre";
                    DropDownList1.DataValueField = "idT";
                    DropDownList1.DataBind();
                    lector.Close();
                    con.Close();
                }
                else
                {
                    DropDownList1.Items.Add("No hay elementos");
                }
            }
            if (!(DropDownList2.Items.Count > 0))
            {
                String query = "select cLibro, titulo from Libro";
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                OdbcDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    DropDownList2.DataSource = lector;
                    DropDownList2.DataTextField = "titulo";
                    DropDownList2.DataValueField = "cLibro";
                    DropDownList2.DataBind();
                    lector.Close();
                    con.Close();
                }
                else
                {
                    DropDownList1.Items.Add("No hay elementos");
                }
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
            String nomS = TextBox1.Text;
            String idT = DropDownList1.SelectedValue.ToString();
            String idL = DropDownList2.SelectedValue.ToString();
            int idSala = 1;
            if (nomS.Length>3)
            {
                int Cupo = (TextBox2.Text.Length > 0) ? Int32.Parse(TextBox2.Text.ToString()) : 50;
                Cupo = (Cupo > 50) ? 50 : Cupo;


                String query = "select top(1) cSala from Sala order by cSala desc";
                OdbcConnection conID = new ConexionBD().conexion;
                OdbcCommand comandoID = new OdbcCommand(query, conID);
                OdbcDataReader lectorID = comandoID.ExecuteReader();
                if (lectorID.HasRows)
                {
                    lectorID.Read();
                    idSala = Int32.Parse(lectorID.GetValue(0).ToString()) + 1;
                }
                DateTime fecha = DateTime.Now;
                String fechaCreacion = fecha.Year+"-"+fecha.Month+"-"+fecha.Day;
                String fechaCierre = (Int32.Parse(fecha.Year.ToString())+2) + "-" + fecha.Month + "-" + fecha.Day;

                query = "insert into Sala values	(?, ?, ?, ?, ?, ?, ?, ?)";
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("cSala", idSala);
                comando.Parameters.AddWithValue("nombre", nomS);
                comando.Parameters.AddWithValue("anfitrion", Session["clave"].ToString());
                comando.Parameters.AddWithValue("idTema", idT);
                comando.Parameters.AddWithValue("idLibro", idL);
                comando.Parameters.AddWithValue("FechaC", fechaCreacion);
                comando.Parameters.AddWithValue("FechaCierre", fechaCierre);
                comando.Parameters.AddWithValue("Cupo", Cupo);
                comando.ExecuteNonQuery();
                Label2.Text = "Sala creada con exito";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                Label2.Text = "Completa correctamente el nombre de la sala";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioUsuario.aspx");

        }
    }
}