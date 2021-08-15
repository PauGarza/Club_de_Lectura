using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Club_de_Lectura
{
    public partial class CRUDUsuariosAdmin1 : System.Web.UI.Page
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

            String query = "Select * from Usuario";
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

            String cUsuario = TextBox1.Text;
            TextBox1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = true;
            Button5.Enabled = true;
            Button6.Enabled = false;
            Button7.Enabled = false;
            String query = "Select * from Usuario where claveU = ?";
            OdbcConnection con = new ConexionBD().conexion;
            OdbcCommand comando = new OdbcCommand(query, con);
            comando.Parameters.AddWithValue("claveU", cUsuario);
            OdbcDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                lector.Read();
                TextBox2.Text = lector.GetValue(1).ToString();
                TextBox3.Text = lector.GetValue(2).ToString();
                TextBox4.Text = lector.GetValue(3).ToString();
                TextBox5.Text = lector.GetValue(4).ToString();
                TextBox6.Text = lector.GetValue(5).ToString();
                con.Close();
            }
            else
            {
                Label3.Text = "No existe el usuario con clave: " + cUsuario;
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
                String cUsuario = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text.ToString();
                TextBox1.Text = cUsuario;
                TextBox1.Enabled = false;
                Button2.Enabled = false;
                Button6.Enabled = false;
                Button7.Enabled = false;
                String query = "Select * from Usuario where claveU = ?";
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("claveU", cUsuario);
                OdbcDataReader lector = comando.ExecuteReader();
                lector.Read();
                TextBox2.Text = lector.GetValue(1).ToString();
                TextBox3.Text = lector.GetValue(2).ToString();
                TextBox4.Text = lector.GetValue(3).ToString();
                TextBox5.Text = lector.GetValue(4).ToString();
                TextBox6.Text = lector.GetValue(5).ToString();
                con.Close();

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String nom = TextBox2.Text;
            String correo = TextBox3.Text;
            String contra = TextBox4.Text;
            String tel = TextBox5.Text;
            String dir = TextBox6.Text;
            String CU = TextBox1.Text;
            int rowsA = 0;
            try
            {
                String query = "UPDATE usuario SET nombre = ?, correo = ?, contraseña = ?, telefono = ?, direccion = ? WHERE claveU= ?";

                ConexionBD objetoConexion = new ConexionBD();
                OdbcConnection con = objetoConexion.conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("nombre", nom);
                comando.Parameters.AddWithValue("correo", correo);
                comando.Parameters.AddWithValue("contraseña", contra);
                comando.Parameters.AddWithValue("telefono", tel);
                comando.Parameters.AddWithValue("direccion", dir);
                comando.Parameters.AddWithValue("claveU", CU);
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
            String cUsuario = TextBox1.Text;
            String queryS = "delete from seUne where idSala in (select cSala from Sala where anfitrion = ?)";
            OdbcConnection conS = new ConexionBD().conexion;
            OdbcCommand comandoS = new OdbcCommand(queryS, conS);
            comandoS.Parameters.AddWithValue("anfitrion", cUsuario);
            comandoS.ExecuteNonQuery();
            conS.Close();

            String queryR = "delete from Reunion where idSala in (select cSala from Sala where anfitrion = ?)";
            OdbcConnection conR = new ConexionBD().conexion;
            OdbcCommand comandoR = new OdbcCommand(queryR, conR);
            comandoR.Parameters.AddWithValue("anfitrion", cUsuario);
            comandoR.ExecuteNonQuery();
            conR.Close();

            String querySS = "delete from Sala where anfitrion = ?";
            OdbcConnection conSS = new ConexionBD().conexion;
            OdbcCommand comandoSS = new OdbcCommand(querySS, conSS);
            comandoSS.Parameters.AddWithValue("anfitrion", cUsuario);
            comandoSS.ExecuteNonQuery();
            conSS.Close();

            String query = "delete from Usuario where claveU = ?";
            OdbcConnection con = new ConexionBD().conexion;
            OdbcCommand comando = new OdbcCommand(query, con);
            comando.Parameters.AddWithValue("claveU", cUsuario);
            comando.ExecuteNonQuery();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            Label3.Text = "Eliminado con exito";
            Response.Redirect("CRUDUsuariosAdmin.aspx");
            con.Close();
        }

        protected void Button6_Click1(object sender, EventArgs e)
        {

            Button7.Enabled = false;
            String CU = "";
            String nom = TextBox2.Text;
            String c = TextBox3.Text;
            String p = TextBox4.Text;
            String t = TextBox5.Text;
            String d = TextBox6.Text;
            if (nom.Length > 0 && c.Length > 0 && p.Length > 0 && t.Length > 0 && d.Length > 0)
            {
                if (nom.Length >= 5)
                {
                    int Nlng = nom.Length;
                    int Tlng = t.Length;
                    Random rand = new Random();
                    int vuelta = 0;
                    OdbcDataReader lec1;
                    Boolean lineas = false;
                    do
                    {
                        vuelta++;
                        String sp = nom.Substring(Nlng - 2, 2);
                        if (sp.Contains("ñ"))
                        {
                            CU = "" + nom.Substring(0, 2) + "oth" + t.Substring(Tlng - 2, 2) + vuelta;
                        }
                        else
                        {
                            CU = "" + nom.Substring(0, 2) + sp + t.Substring(Tlng - 2, 2) + vuelta;
                        }
                        String query1 = "select * from Usuario where claveU = ?";
                        OdbcConnection con1 = new ConexionBD().conexion;
                        OdbcCommand comando1 = new OdbcCommand(query1, con1);
                        comando1.Parameters.AddWithValue("claveU", CU);
                        lec1 = comando1.ExecuteReader();
                        lineas = lec1.HasRows;
                        con1.Close();
                    } while (lineas);

                    String query2 = "insert into Usuario values (?, ?, ?, ?, ?, ?)";

                    try
                    {
                        OdbcConnection con2 = new ConexionBD().conexion;
                        OdbcCommand comando2 = new OdbcCommand(query2, con2);
                        comando2.Parameters.AddWithValue("claveU", CU);
                        comando2.Parameters.AddWithValue("nombre", nom);
                        comando2.Parameters.AddWithValue("correo", c);
                        comando2.Parameters.AddWithValue("contraseña", p);
                        comando2.Parameters.AddWithValue("telefono", t);
                        comando2.Parameters.AddWithValue("direccion", d);
                        comando2.ExecuteNonQuery();
                        Label3.Text = "CUENTA CREADA \n Tu Clave de acceso es: " + CU;
                        con2.Close();
                    }
                    catch (Exception ex)
                    {
                        Label3.Text = "Error al crear cuenta" + ex;
                    }
                }
                else
                {
                    Label3.Text = "Nombre muy corto, agrega segundo nombre o primer apellido";
                }
            }
            else
            {
                Label3.Text = "Algunos de los campos no fue completado";
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
            Response.Redirect("CRUDUsuariosAdmin.aspx");
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