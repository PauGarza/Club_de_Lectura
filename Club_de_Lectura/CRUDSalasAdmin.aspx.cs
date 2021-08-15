using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Club_de_Lectura
{
    public partial class CRUDSalasAdmin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["claveA"] == null || Session["nombreA"] == null)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("LoginAdmin.aspx");
            }
            Label1.Text = Session["nombreA"].ToString();

            String query = "Select * from Sala";
            OdbcConnection con = new ConexionBD().conexion;
            OdbcCommand comando = new OdbcCommand(query, con);
            OdbcDataReader lector = comando.ExecuteReader();
            GridView1.DataSource = lector;
            GridView1.AutoGenerateSelectButton = true;
            GridView1.DataBind();
            con.Close();
            Button2.Enabled = true;
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button6.Enabled = false;
            if (!(DropDownList1.Items.Count > 0))
            {
                String query1 = "select claveU, nombre from Usuario";
                OdbcConnection con1 = new ConexionBD().conexion;
                OdbcCommand comando1 = new OdbcCommand(query1, con1);
                OdbcDataReader lector1 = comando1.ExecuteReader();
                if (lector1.HasRows)
                {
                    DropDownList1.DataSource = lector1;
                    DropDownList1.DataTextField = "nombre";
                    DropDownList1.DataValueField = "claveU";
                    DropDownList1.DataBind();
                    lector1.Close();
                    con1.Close();
                }
                else
                {
                    DropDownList1.Items.Add("No hay elementos");
                }
            }
            if (!(DropDownList2.Items.Count > 0))
            {
                String query2 = "select idT, nombre from Temas";
                OdbcConnection con2 = new ConexionBD().conexion;
                OdbcCommand comando2 = new OdbcCommand(query2, con2);
                OdbcDataReader lector2 = comando2.ExecuteReader();
                if (lector2.HasRows)
                {
                    DropDownList2.DataSource = lector2;
                    DropDownList2.DataTextField = "nombre";
                    DropDownList2.DataValueField = "idT";
                    DropDownList2.DataBind();
                    lector2.Close();
                    con2.Close();
                }
                else
                {
                    DropDownList2.Items.Add("No hay elementos");
                }
            }
            if (!(DropDownList3.Items.Count > 0))
            {
                String query3 = "select cLibro, titulo from Libro";
                OdbcConnection con3 = new ConexionBD().conexion;
                OdbcCommand comando3 = new OdbcCommand(query3, con3);
                OdbcDataReader lector3 = comando3.ExecuteReader();
                if (lector3.HasRows)
                {
                    DropDownList3.DataSource = lector3;
                    DropDownList3.DataTextField = "titulo";
                    DropDownList3.DataValueField = "cLibro";
                    DropDownList3.DataBind();
                    lector3.Close();
                    con3.Close();
                }
                else
                {
                    DropDownList3.Items.Add("No hay elementos");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("LoginAdmin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String cSala = TextBox1.Text;
            TextBox1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = true;
            Button5.Enabled = true;
            Button6.Enabled = false;
            Button7.Enabled = false;
            String query = "Select * from Sala where cSala = ?";
            OdbcConnection con = new ConexionBD().conexion;
            OdbcCommand comando = new OdbcCommand(query, con);
            comando.Parameters.AddWithValue("cSala", cSala);
            OdbcDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                lector.Read();
                TextBox2.Text = lector.GetValue(1).ToString();
                DropDownList1.SelectedValue = lector.GetValue(2).ToString();
                DropDownList2.SelectedValue = lector.GetValue(3).ToString();
                DropDownList3.SelectedValue = lector.GetValue(4).ToString();
                TextBox6.Text = lector.GetValue(5).ToString();
                con.Close();
            }
            else
            {
                Label3.Text = "No existe la sala con clave: " + cSala;
                Button4.Enabled = false;
                Button5.Enabled = false;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Label3.Text = "";
            if (GridView1.SelectedIndex >= 0)
            {
                Button4.Enabled = true;
                Button5.Enabled = true;
                String cSala = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString();
                TextBox1.Text = cSala;
                TextBox1.Enabled = false;
                Button2.Enabled = false;
                Button6.Enabled = false;
                Button7.Enabled = false;
                String query = "Select * from Sala where cSala = ?";
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("cSala", cSala);
                OdbcDataReader lector = comando.ExecuteReader();
                lector.Read();
                TextBox2.Text = lector.GetValue(1).ToString();
                DropDownList1.SelectedValue = lector.GetValue(2).ToString();
                DropDownList2.SelectedValue = lector.GetValue(3).ToString();
                DropDownList3.SelectedValue = lector.GetValue(4).ToString();
                TextBox6.Text = lector.GetValue(7).ToString();
                con.Close();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String nom = TextBox2.Text;
            String anf = DropDownList1.SelectedValue.ToString();
            String tema = DropDownList2.SelectedValue.ToString();
            String libro = DropDownList3.SelectedValue.ToString();
            int cupo = Int32.Parse(TextBox6.Text);
            cupo = (cupo<=50)?cupo:50;
            String cSala = TextBox1.Text;
            int rowsA = 0;
            try
            {
                String query = "UPDATE Sala SET nombre = ?, anfitrion = ?, idTema = ?, idLibro = ?, Cupo = ? WHERE cSala= ?";

                ConexionBD objetoConexion = new ConexionBD();
                OdbcConnection con = objetoConexion.conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("nombre", nom);
                comando.Parameters.AddWithValue("anfitrion", anf);
                comando.Parameters.AddWithValue("idTema", tema);
                comando.Parameters.AddWithValue("idLibro", libro);
                comando.Parameters.AddWithValue("Cupo", cupo);
                comando.Parameters.AddWithValue("cSala", cSala);
                rowsA = comando.ExecuteNonQuery();
                con.Close();
                if (rowsA > 0)
                {
                    Label3.Text = "Actualizado con exito";

                }
                else
                {
                    Label3.Text = "No actualizado";
                }
            }
            catch (Exception ex)
            {
                Label3.Text = "" + ex;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            String idSala = TextBox1.Text;
            String queryS = "delete from seUne where idSala = ?";
            OdbcConnection conS = new ConexionBD().conexion;
            OdbcCommand comandoS = new OdbcCommand(queryS, conS);
            comandoS.Parameters.AddWithValue("idSala", idSala);
            comandoS.ExecuteNonQuery();
            conS.Close();

            String queryR = "delete from Reunion where idSala = ?";
            OdbcConnection conR = new ConexionBD().conexion;
            OdbcCommand comandoR = new OdbcCommand(queryR, conR);
            comandoR.Parameters.AddWithValue("idSala", idSala);
            comandoR.ExecuteNonQuery();
            conR.Close();

            String querySS = "delete from Sala where cSala = ?";
            OdbcConnection conSS = new ConexionBD().conexion;
            OdbcCommand comandoSS = new OdbcCommand(querySS, conSS);
            comandoSS.Parameters.AddWithValue("cSala", idSala);
            comandoSS.ExecuteNonQuery();

            TextBox1.Text = "";
            TextBox2.Text = "";
            DropDownList1.SelectedIndex = 1; 
            DropDownList2.SelectedIndex = 1;
            DropDownList3.SelectedIndex = 1;
            TextBox6.Text = "";
            Label3.Text = "Eliminado con exito";
            Response.Redirect("CRUDSalasAdmin.aspx");
            conSS.Close();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            String nomS = TextBox2.Text;
            String anf = DropDownList1.SelectedValue.ToString();
            String idT = DropDownList2.SelectedValue.ToString();
            String idL = DropDownList3.SelectedValue.ToString();
            int idSala = 1;
            if (nomS.Length > 3)
            {
                int Cupo = (TextBox6.Text.Length > 0) ? Int32.Parse(TextBox6.Text.ToString()) : 50;
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
                String fechaCreacion = fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
                String fechaCierre = (Int32.Parse(fecha.Year.ToString()) + 2) + "-" + fecha.Month + "-" + fecha.Day;

                query = "insert into Sala values	(?, ?, ?, ?, ?, ?, ?, ?)";
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("cSala", idSala);
                comando.Parameters.AddWithValue("nombre", nomS);
                comando.Parameters.AddWithValue("anfitrion", anf);
                comando.Parameters.AddWithValue("idTema", idT);
                comando.Parameters.AddWithValue("idLibro", idL);
                comando.Parameters.AddWithValue("FechaC", fechaCreacion);
                comando.Parameters.AddWithValue("FechaCierre", fechaCierre);
                comando.Parameters.AddWithValue("Cupo", Cupo);
                comando.ExecuteNonQuery();
                Label3.Text = "Sala creada con exito";
            }
            else
            {
                Label3.Text = "Completa correctamente el nombre de la sala";
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            TextBox1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button6.Enabled = true;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("CRUDSalasAdmin.aspx");

        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioAdmin.aspx");

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label2.Text = "Clave Seleccionada: " + GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString();
            Button3.Enabled = true;
            Button7.Enabled = false;
            Button2.Enabled = false;
            TextBox1.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString();
        }
    }
}