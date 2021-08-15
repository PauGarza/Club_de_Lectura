using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Club_de_Lectura
{
    public partial class CRUDTemasAdmin1 : System.Web.UI.Page
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

            String query = "Select * from Temas";
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("LoginAdmin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String cTema = TextBox1.Text;
            TextBox1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = true;
            Button5.Enabled = true;
            Button6.Enabled = false;
            Button7.Enabled = false;
            String query = "Select * from Temas where idT = ?";
            OdbcConnection con = new ConexionBD().conexion;
            OdbcCommand comando = new OdbcCommand(query, con);
            comando.Parameters.AddWithValue("idT", cTema);
            OdbcDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                lector.Read();
                TextBox2.Text = lector.GetValue(1).ToString();
                con.Close();
            }
            else
            {
                Label3.Text = "No existe el tema con clave: " + cTema;
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
                String cTema = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString();
                TextBox1.Text = cTema;
                TextBox1.Enabled = false;
                Button2.Enabled = false;
                Button6.Enabled = false;
                Button7.Enabled = false;
                String query = "Select * from Temas where idT = ?";
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("idT", cTema);
                OdbcDataReader lector = comando.ExecuteReader();
                lector.Read();
                TextBox2.Text = lector.GetValue(1).ToString();
                con.Close();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String nom = TextBox2.Text;
            String cTema = TextBox1.Text;
            int rowsA = 0;
            try
            {
                String query = "UPDATE Temas SET nombre = ? WHERE idT= ?";

                ConexionBD objetoConexion = new ConexionBD();
                OdbcConnection con = objetoConexion.conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("nombre", nom);
                comando.Parameters.AddWithValue("idT", cTema);
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
           String cTema = TextBox1.Text;
            String queryS = "delete from seUne where idSala in (select cSala from Sala where idTema = ?)";
            OdbcConnection conS = new ConexionBD().conexion;
            OdbcCommand comandoS = new OdbcCommand(queryS, conS);
            comandoS.Parameters.AddWithValue("idTema", cTema);
            comandoS.ExecuteNonQuery();
            conS.Close();

            String queryR = "delete from Reunion where idSala in (select cSala from Sala where idTema = ?)";
            OdbcConnection conR = new ConexionBD().conexion;
            OdbcCommand comandoR = new OdbcCommand(queryR, conR);
            comandoR.Parameters.AddWithValue("idTema", cTema);
            comandoR.ExecuteNonQuery();
            conR.Close();

            String querySS = "delete from Sala where idTema = ?";
            OdbcConnection conSS = new ConexionBD().conexion;
            OdbcCommand comandoSS = new OdbcCommand(querySS, conSS);
            comandoSS.Parameters.AddWithValue("cSala", cTema);
            comandoSS.ExecuteNonQuery();
            conSS.Close();

            String queryT = "delete from Temas where idT = ?";
            OdbcConnection conT = new ConexionBD().conexion;
            OdbcCommand comandoT = new OdbcCommand(queryT, conT);
            comandoT.Parameters.AddWithValue("idT", cTema);
            comandoT.ExecuteNonQuery();

            TextBox1.Text = "";
            TextBox2.Text = "";
            Label3.Text = "Eliminado con exito";
            Response.Redirect("CRUDTemasAdmin.aspx");
            conT.Close();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            String nomT = TextBox2.Text;
            int idT = 1;
            if (nomT.Length > 3)
            {

                String query = "select top(1) idT from Temas order by idT desc";
                OdbcConnection conID = new ConexionBD().conexion;
                OdbcCommand comandoID = new OdbcCommand(query, conID);
                OdbcDataReader lectorID = comandoID.ExecuteReader();
                if (lectorID.HasRows)
                {
                    lectorID.Read();
                    idT = Int32.Parse(lectorID.GetValue(0).ToString()) + 1;
                }

                query = "insert into Temas values	(?, ?)";
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("idT", idT);
                comando.Parameters.AddWithValue("nombre", nomT);
                comando.ExecuteNonQuery();
                Label3.Text = "Tema creado con exito";
            }
            else
            {
                Label3.Text = "Completa correctamente el nombre del tema";
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
            Response.Redirect("CRUDTemasAdmin.aspx");

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