using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Club_de_Lectura
{
    public partial class MisSalasU1 : System.Web.UI.Page
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
                DropDownList1.Items.Add("Creadas por mi");
                DropDownList1.Items.Add("A las que me uni");
                MostrarCreadas(false);
                MostrarUnidas(false);
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
            GridView1.SelectedIndex = -1;
            TextBox1.Text = "";
            TextBox2.Text = "";
            DropDownList2.SelectedIndex = -1;
            DropDownList3.SelectedIndex = -1;

            int seleccion = DropDownList1.SelectedIndex;
            if (seleccion == 0)
            {
                MostrarCreadas(true);
                MostrarUnidas(false);
                String query = "select Sala.cSala, sala.nombre, Temas.nombre as 'Tema', Libro.titulo as 'Libro', Sala.FechaC as 'Creacion', Sala.FechaCierre as 'Cierre' from Sala " +
                    "inner join Temas on Sala.idTema = Temas.idT " +
                    "inner join Libro on Sala.idLibro = Libro.cLibro " +
                "where Sala.anfitrion = ?";
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("Sala.anfitrion", Session["clave"].ToString());

                OdbcDataReader lector = comando.ExecuteReader();
                GridView1.DataSource = lector;
                GridView1.AutoGenerateSelectButton = true;
                GridView1.DataBind();
                con.Close();

            }
            else
            {
                MostrarCreadas(false);
                MostrarUnidas(true);
                String query = "select Sala.cSala, sala.nombre, Usuario.nombre as 'Anfitrion', Temas.nombre as 'Tema', Libro.titulo as 'Libro', Sala.FechaC as 'Creacion', Sala.FechaCierre as 'Cierre' from Sala " +
                    "inner join Temas on Sala.idTema = Temas.idT " +
                    "inner join Libro on Sala.idLibro =  Libro.cLibro " +
                    "inner join Usuario on Sala.anfitrion = Usuario.claveU "+
                "where Sala.anfitrion <> ? and Sala.cSala in(select seUne.idSala from seUne where idUsuario = ?)";
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("Sala.anfitrion", Session["clave"].ToString());
                comando.Parameters.AddWithValue("idUsuario", Session["clave"].ToString());

                OdbcDataReader lector = comando.ExecuteReader();
                GridView1.DataSource = lector;
                GridView1.AutoGenerateSelectButton = true;
                GridView1.DataBind();
                con.Close();
            }
        }
        protected void MostrarUnidas(Boolean state)
        {
            Button7.Enabled = state;
            Button7.Visible = state;
        }
        protected void MostrarCreadas(Boolean state)
        {
            Button4.Enabled = state;
            Button4.Visible = state;
            Button5.Enabled = state;
            Button5.Visible = state;
            Button6.Enabled = state;
            Button6.Visible = state;

            Label2.Enabled = state;
            Label2.Visible = state;
            Label3.Enabled = state;
            Label3.Visible = state;
            Label4.Enabled = state;
            Label4.Visible = state;
            Label5.Enabled = state;
            Label5.Visible = state;
            Label6.Enabled = state;
            Label6.Visible = state;

            TextBox1.Enabled = state;
            TextBox1.Visible = state;
            TextBox2.Enabled = state;
            TextBox2.Visible = state;

            DropDownList2.Enabled = state;
            DropDownList2.Visible = state;
            DropDownList3.Enabled = state;
            DropDownList3.Visible = state;
            DropDownList4.Enabled = state;
            DropDownList4.Visible = state;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label7.Text = "Sala seleccionada: "+GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString();
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex>=0)
            {
                String query = "select idReunion,duracion, fechaR as 'Fecha', idSala as 'Sala' from Reunion where idSala = ?";
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("idSala", GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString());

                OdbcDataReader lector = comando.ExecuteReader();
                GridView2.DataSource = lector;
                GridView2.AutoGenerateSelectButton = true;
                GridView2.DataBind();
                con.Close();
            }
           

            if (!(DropDownList3.Items.Count > 0))
            {
                String queryT = "select idT, nombre from Temas";
                OdbcConnection conT = new ConexionBD().conexion;
                OdbcCommand comandoT = new OdbcCommand(queryT, conT);
                OdbcDataReader lectorT = comandoT.ExecuteReader();
                if (lectorT.HasRows)
                {
                    DropDownList3.DataSource = lectorT;
                    DropDownList3.DataTextField = "nombre";
                    DropDownList3.DataValueField = "idT";
                    DropDownList3.DataBind();
                    lectorT.Close();
                    conT.Close();
                }
                else
                {
                    DropDownList3.Items.Add("No hay elementos");
                }
            }
            if (!(DropDownList2.Items.Count > 0))
            {
                String queryL = "select cLibro, titulo from Libro";
                OdbcConnection conL = new ConexionBD().conexion;
                OdbcCommand comandoL = new OdbcCommand(queryL, conL);
                OdbcDataReader lectorL = comandoL.ExecuteReader();
                if (lectorL.HasRows)
                {
                    DropDownList2.DataSource = lectorL;
                    DropDownList2.DataTextField = "titulo";
                    DropDownList2.DataValueField = "cLibro";
                    DropDownList2.DataBind();
                    lectorL.Close();
                    conL.Close();
                }
                else
                {
                    DropDownList1.Items.Add("No hay elementos");
                }
            }
            if (!(DropDownList4.Items.Count > 0))
            {
                DropDownList4.Items.Add("Si");
                DropDownList4.Items.Add("No");
            }
            //Rellenar campos
            if (GridView1.SelectedIndex >= 0)
            {
                String queryCampos = "select nombre, idLibro, idTema, Cupo from Sala where cSala = ?";
                OdbcConnection conCampos = new ConexionBD().conexion;
                OdbcCommand comandoCampos = new OdbcCommand(queryCampos, conCampos);
                comandoCampos.Parameters.AddWithValue("cSala", GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString());
                OdbcDataReader lectorCampos = comandoCampos.ExecuteReader();

                if (lectorCampos.HasRows)
                {
                    lectorCampos.Read();
                    TextBox1.Text = lectorCampos.GetValue(0).ToString();
                    DropDownList2.SelectedValue = lectorCampos.GetValue(1).ToString();
                    DropDownList3.SelectedValue = lectorCampos.GetValue(2).ToString();
                    TextBox2.Text = lectorCampos.GetValue(3).ToString();

                }
                conCampos.Close();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            String fechaRenov = "";
            String nombre = TextBox1.Text;
            int idL = Int32.Parse(DropDownList2.SelectedValue.ToString());
            int idT = Int32.Parse(DropDownList3.SelectedValue.ToString());
            int cupo = Int32.Parse(TextBox2.Text);
            cupo = (cupo<=50)?cupo:50;

            if (DropDownList4.SelectedIndex == 0)
            {
                DateTime fecha = DateTime.Now;
                fechaRenov = ", FechaCierre = "+fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
            }

            String queryCampos = "Update Sala SET nombre = ?, idLibro = ?, idTema = ?, Cupo = ?"+fechaRenov+" where cSala = ?";
            OdbcConnection conCampos = new ConexionBD().conexion;
            OdbcCommand comandoCampos = new OdbcCommand(queryCampos, conCampos); 
            comandoCampos.Parameters.AddWithValue("nombre", nombre);
            comandoCampos.Parameters.AddWithValue("idLibro", idL);
            comandoCampos.Parameters.AddWithValue("idTema", idT);
            comandoCampos.Parameters.AddWithValue("Cupo", cupo);
            comandoCampos.Parameters.AddWithValue("cSala", GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString());
            comandoCampos.ExecuteNonQuery();
            Label8.Text = "Campos Actualizados";
            conCampos.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String querySeUne = "delete from seUne where idSala = ?";
            OdbcConnection conSeUne = new ConexionBD().conexion;
            OdbcCommand comandoSeUne = new OdbcCommand(querySeUne, conSeUne);
            comandoSeUne.Parameters.AddWithValue("cSala", GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString());
            comandoSeUne.ExecuteNonQuery();

            String querySala = "delete from Sala where cSala = ?";
            OdbcConnection conSala = new ConexionBD().conexion;
            OdbcCommand comandoSala = new OdbcCommand(querySala, conSala);
            comandoSala.Parameters.AddWithValue("cSala", GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString());
            comandoSala.ExecuteNonQuery();
            Response.Redirect("MisSalasU.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //Agregar Reunion
            if (GridView1.SelectedIndex>=0)
            {
                Session["Sala"] = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString();
                Response.Redirect("NuevaReunionU.aspx");
            }

        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioUsuario.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex >= 0)
            {
                String querySeUne = "delete from seUne where idSala = ? and idUsuario = ?";
                OdbcConnection conSeUne = new ConexionBD().conexion;
                OdbcCommand comandoSeUne = new OdbcCommand(querySeUne, conSeUne);
                comandoSeUne.Parameters.AddWithValue("cSala", GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString());
                comandoSeUne.Parameters.AddWithValue("idUsuario", Session["clave"]);
                comandoSeUne.ExecuteNonQuery();
            }
            Response.Redirect("MisSalasU.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex >= 0 && GridView2.SelectedIndex >= 0)
            {
                Session["estado"] = DropDownList1.SelectedIndex;
                Session["Sala"] = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString();
                Session["Reu"] = GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text.ToString();
                Response.Redirect("DetallesRU.aspx");
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label9.Text = GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text.ToString();

        }
    }
}