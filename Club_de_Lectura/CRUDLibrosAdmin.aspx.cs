using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Club_de_Lectura
{
    public partial class CRUDLibrosAdmin1 : System.Web.UI.Page
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

            String query = "Select * from Libro";
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
                String queryG = "select cGen, nombre from Genero";
                OdbcConnection conG = new ConexionBD().conexion;
                OdbcCommand comandoG = new OdbcCommand(queryG, conG);
                OdbcDataReader lectorG = comandoG.ExecuteReader();
                if (lectorG.HasRows)
                {
                    DropDownList1.DataSource = lectorG;
                    DropDownList1.DataTextField = "nombre";
                    DropDownList1.DataValueField = "cGen";
                    DropDownList1.DataBind();
                    lectorG.Close();
                    conG.Close();
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
            Response.Redirect("LoginAdmin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String cLibro = TextBox1.Text;
            TextBox1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = true;
            Button5.Enabled = true;
            Button6.Enabled = false;
            Button7.Enabled = false;
            String query = "Select * from Libro where cLibro = ?";
            OdbcConnection con = new ConexionBD().conexion;
            OdbcCommand comando = new OdbcCommand(query, con);
            comando.Parameters.AddWithValue("cLibro", cLibro);
            OdbcDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                lector.Read(); 
                TextBox2.Text = lector.GetValue(1).ToString();
                TextBox3.Text = lector.GetValue(2).ToString();
                TextBox4.Text = lector.GetValue(3).ToString();
                DropDownList1.SelectedValue = lector.GetValue(4).ToString();
                TextBox5.Text = lector.GetValue(5).ToString();
                con.Close();
            }
            else
            {
                Label3.Text = "No existe el libro con clave: " + cLibro;
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
                String cLibro = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString();
                TextBox1.Text = cLibro;
                TextBox1.Enabled = false;
                Button2.Enabled = false;
                Button6.Enabled = false;
                Button7.Enabled = false;
                String query = "Select * from Libro where cLibro = ?";
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("cLibro", cLibro);
                OdbcDataReader lector = comando.ExecuteReader();
                lector.Read();
                TextBox2.Text = lector.GetValue(1).ToString();
                TextBox3.Text = lector.GetValue(2).ToString();
                TextBox4.Text = lector.GetValue(3).ToString();
                DropDownList1.SelectedValue = lector.GetValue(4).ToString();
                TextBox5.Text = lector.GetValue(5).ToString();
                con.Close();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String cLibro = TextBox1.Text;
            String tit =    TextBox2.Text;
            String reseña = TextBox3.Text;
            String ISBN =   TextBox4.Text;
            String cGen =   DropDownList1.SelectedValue.ToString();
            String autor =  TextBox5.Text;

            int rowsA = 0;
            try
            {
                String query = "UPDATE Libro SET titulo = ?, reseña = ?, ISBN = ?, cGen = ?, autor = ? WHERE cLibro= ?";

                ConexionBD objetoConexion = new ConexionBD();
                OdbcConnection con = objetoConexion.conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("titulo", tit);
                comando.Parameters.AddWithValue("reseña", reseña);
                comando.Parameters.AddWithValue("ISBN", ISBN);
                comando.Parameters.AddWithValue("cGen", cGen);
                comando.Parameters.AddWithValue("autor", autor);
                comando.Parameters.AddWithValue("cLibro", cLibro);
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
            String idLibro = TextBox1.Text;
            String queryS = "delete from seUne where idSala in (select cSala from Sala where idLibro = ?)";
            OdbcConnection conS = new ConexionBD().conexion;
            OdbcCommand comandoS = new OdbcCommand(queryS, conS);
            comandoS.Parameters.AddWithValue("idLibro", idLibro);
            comandoS.ExecuteNonQuery();
            conS.Close();

            String queryR = "delete from Reunion where idSala in (select cSala from Sala where idLibro = ?)";
            OdbcConnection conR = new ConexionBD().conexion;
            OdbcCommand comandoR = new OdbcCommand(queryR, conR);
            comandoR.Parameters.AddWithValue("idLibro", idLibro);
            comandoR.ExecuteNonQuery();
            conR.Close();

            String querySS = "delete from Sala where idLibro = ?";
            OdbcConnection conSS = new ConexionBD().conexion;
            OdbcCommand comandoSS = new OdbcCommand(querySS, conSS);
            comandoSS.Parameters.AddWithValue("idLibro", idLibro);
            comandoSS.ExecuteNonQuery();
            conSS.Close();

            String queryL = "delete from Libro where cLibro = ?";
            OdbcConnection conL = new ConexionBD().conexion;
            OdbcCommand comandoL = new OdbcCommand(queryL, conL);
            comandoL.Parameters.AddWithValue("cLibro", idLibro);
            comandoL.ExecuteNonQuery();

            TextBox1.Text = "";
            TextBox2.Text = "";
            Label3.Text = "Eliminado con exito";
            Response.Redirect("CRUDLibrosAdmin.aspx");
            conL.Close();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            String tit = TextBox2.Text;
            String reseña = TextBox3.Text;
            String ISBN = TextBox4.Text;
            String cGen = DropDownList1.SelectedValue.ToString();
            String autor = TextBox5.Text;
            int cLibro = 1;
            if (tit.Length > 3)
            {
                if (ISBN.Length<=13)
                {
                    String query = "select top(1) cLibro from Libro order by cLibro desc";
                    OdbcConnection conID = new ConexionBD().conexion;
                    OdbcCommand comandoID = new OdbcCommand(query, conID);
                    OdbcDataReader lectorID = comandoID.ExecuteReader();
                    if (lectorID.HasRows)
                    {
                        lectorID.Read();
                        cLibro = Int32.Parse(lectorID.GetValue(0).ToString()) + 1000;
                    }

                    query = "insert into Libro values (?,?,?,?, ?, ?)";
                    OdbcConnection con = new ConexionBD().conexion;
                    OdbcCommand comando = new OdbcCommand(query, con);
                    comando.Parameters.AddWithValue("cLibro", cLibro);
                    comando.Parameters.AddWithValue("titulo", tit);
                    comando.Parameters.AddWithValue("reseña", reseña);
                    comando.Parameters.AddWithValue("ISBN", ISBN);
                    comando.Parameters.AddWithValue("cGen", cGen);
                    comando.Parameters.AddWithValue("autor", autor);
                    comando.ExecuteNonQuery();
                    Label3.Text = "Libro creado con exito";
                }
                else
                {
                    Label3.Text = "ISBN no valido";
                }

            }
            else
            {
                Label3.Text = "Completa correctamente el titulo del Libro";
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
            Response.Redirect("CRUDLibrosAdmin.aspx");

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