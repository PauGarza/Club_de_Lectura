using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Club_de_Lectura
{
    public partial class UnirseSalaU1 : System.Web.UI.Page
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
            if (!(DropDownList2.Items.Count>0))
            {
                String query = "select cLibro, titulo from Libro";
                OdbcConnection conL = new ConexionBD().conexion;

                OdbcCommand comandoL = new OdbcCommand(query, conL);
                OdbcDataReader lectorL = comandoL.ExecuteReader();

                DropDownList2.DataSource = lectorL;
                DropDownList2.DataTextField = "titulo";
                DropDownList2.DataValueField = "cLibro";
                DropDownList2.DataBind();
                conL.Close();
            }
            if (!(DropDownList3.Items.Count > 0))
            {
                String query = "select idT, nombre from Temas";
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                OdbcDataReader lector = comando.ExecuteReader();
                DropDownList3.DataSource = lector;
                DropDownList3.DataTextField = "nombre";
                DropDownList3.DataValueField = "idT";
                DropDownList3.DataBind();
                lector.Close();
                con.Close();
            }
                
            CheckBox1.Text = "Por Libro";
            CheckBox2.Text = "Por Tema";
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
            String Tema = "";
            String where1 = "";
            String Libro = "";
            String andd = "";
            if(CheckBox1.Checked || CheckBox2.Checked)
            {
                where1 = "where ";
                if (CheckBox1.Checked && CheckBox2.Checked)
                {
                    andd = " and ";
                }
            }
            if (CheckBox1.Checked)
            {
                Libro = "Libro.cLibro = '" + DropDownList2.SelectedValue.ToString()+"'";
            }
            if (CheckBox2.Checked)
            {
                Tema = "Temas.idT = '" + DropDownList3.SelectedValue.ToString() + "'";
            }

            String query = "select distinct Sala.cSala, Sala.nombre as 'Nombre Sala', Sala.Cupo, Usuario.nombre as 'Anfitrion', " +
                "Libro.titulo as 'Libro', Temas.nombre as 'Tema' from Sala	" +
                "inner join Usuario on Sala.anfitrion = Usuario.claveU " +
                "inner join Libro on Sala.idLibro = Libro.cLibro " +
                "inner join Temas on Sala.idTema = Temas.idT " +
                where1 + Libro + andd + Tema;
            OdbcConnection con = new ConexionBD().conexion;
            OdbcCommand comando = new OdbcCommand(query, con);
            OdbcDataReader lector = comando.ExecuteReader();

            GridView1.DataSource = lector;
            GridView1.AutoGenerateSelectButton = true;
            GridView1.DataBind();
            //Label2.Text = where1 + Libro + andd + Tema;
            con.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int idS = Int32.Parse(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString());
            String query = "select count(idSala) from seUne where idSala = ?";
            OdbcConnection conR = new ConexionBD().conexion;
            OdbcCommand comandoR = new OdbcCommand(query, conR);
            comandoR.Parameters.AddWithValue("idSala", idS);
            OdbcDataReader lectorR = comandoR.ExecuteReader();
            lectorR.Read();
            int registros = Int32.Parse(lectorR.GetValue(0).ToString());


            query = "select cupo from Sala where cSala = ?";
            OdbcConnection conC = new ConexionBD().conexion;
            OdbcCommand comandoC = new OdbcCommand(query, conC);
            comandoC.Parameters.AddWithValue("cSala", idS);

            OdbcDataReader lectorC = comandoC.ExecuteReader();
            lectorC.Read();
            int cupo = Int32.Parse(lectorC.GetValue(0).ToString());
            if (registros<=(cupo-1))
            {
                try
                {
                    DateTime fecha = DateTime.Now;
                    String fechaCreacion = fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
                    query = "insert into seUne values (?, ?, ?)";
                    OdbcConnection conI = new ConexionBD().conexion;
                    OdbcCommand comandoI = new OdbcCommand(query, conI);
                    comandoI.Parameters.AddWithValue("idSala", idS);
                    comandoI.Parameters.AddWithValue("idUsuario", Session["clave"].ToString());
                    comandoI.Parameters.AddWithValue("fechaUnion", fechaCreacion);
                    comandoI.ExecuteNonQuery();
                    Label2.Text = "Se registro correctamente a la sala: " + idS;
                }
                catch (Exception ex)
                {
                    Label2.Text = ""+ex;
                    Label2.Text = "No se puede registrar mas de una vez en una sala";
                }
            }
            else
            {
                Label2.Text = "Sala llena";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label2.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioUsuario.aspx");
        }
    }
}