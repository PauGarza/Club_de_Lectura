using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Club_de_Lectura
{
    public partial class DetallesRU1 : System.Web.UI.Page
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
            TextBox5.Enabled = false;
            if (Session["estado"] != null && Session["estado"].ToString().Equals("1"))
            {
                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                TextBox3.Enabled = false;
                TextBox4.Enabled = false;
                TextBox5.Enabled = false;
                DropDownList1.Enabled = false;

                Button3.Enabled = false;
                Button3.Visible = false;
                Button5.Enabled = false;
                Button5.Visible = false;
                Button7.Enabled = false;
                Button7.Visible = false;
            }
            if (Session["Reu"] !=null && Session["Reu"].ToString().Length>0)
            {
                if (!(TextBox5.Text.Length>0)) 
                {
                    String queryC = "select * from Reunion where idReunion = ?";
                    OdbcConnection conC = new ConexionBD().conexion;
                    OdbcCommand comandoC = new OdbcCommand(queryC, conC);
                    comandoC.Parameters.AddWithValue("idReunion", Session["Reu"].ToString());
                    OdbcDataReader lectorC = comandoC.ExecuteReader();
                    if (lectorC.HasRows)
                    {
                        lectorC.Read();
                        TextBox1.Text = lectorC.GetValue(3).ToString();
                        TextBox2.Text = lectorC.GetValue(4).ToString();
                        //  30/11/2020 04:30:00 p. m.
                        String FM = lectorC.GetValue(2).ToString();
                        String Fecha = FM.Substring(6, 4) + "-" + FM.Substring(3, 2) + "-" + FM.Substring(0, 2);
                        String Hora = FM.Substring(11, 5);
                        String FechaC = Fecha + " " + Hora;
                        TextBox3.Text = Fecha;
                        TextBox4.Text = Hora;
                        TextBox5.Text = lectorC.GetValue(0).ToString();

                        //select cSala from Sala where anfitrion = 'Raro5512'
                        String queryS = "select cSala from Sala where anfitrion = ?";
                        OdbcConnection conS = new ConexionBD().conexion;
                        OdbcCommand comandoS = new OdbcCommand(queryS, conS);
                        comandoS.Parameters.AddWithValue("anfitrion", Session["clave"].ToString());
                        OdbcDataReader lectorS = comandoS.ExecuteReader();

                        DropDownList1.DataSource = lectorS;
                        DropDownList1.DataTextField = "cSala";
                        DropDownList1.DataValueField = "cSala";
                        DropDownList1.DataBind();
                        conS.Close();
                        DropDownList1.SelectedValue = lectorC.GetValue(1).ToString();
                    }
                    conC.Close();
                }
            }
                
            else
            {
                Response.Redirect("MisSalasU.aspx");
            }



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

        protected void Button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://meet.google.com");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //update Reunion set idSala = 1, fechaR = '2020-11-30 16:30', duracion = 300, linkR='https:\\www.meet.com\99' where idReunion = 9 
            String linkB = "https://meet.google.com/";
            String Fecha = TextBox3.Text;
            String Hora = TextBox4.Text;
            int Duracion = Int32.Parse(TextBox1.Text);
            String Link = TextBox2.Text;

            int idSala = Int32.Parse(DropDownList1.SelectedValue.ToString());
            int idR = Int32.Parse(Session["Reu"].ToString());
            if (Fecha.Length == 10 && Fecha.Substring(4, 1).Equals("-") && Fecha.Substring(7, 1).Equals("-"))
            {
                if (Hora.Length == 5 && Hora.Substring(2, 1).Equals(":"))
                {
                    if (Link.Length > linkB.Length && Link.Substring(0, 24).Equals(linkB))
                    {
                        Fecha = Fecha + " " + Hora;
                      
                        String query = "update Reunion set idSala = ?, fechaR = ?, duracion = ?, linkR=? where idReunion = ?";
                        OdbcConnection con = new ConexionBD().conexion;
                        OdbcCommand comando = new OdbcCommand(query, con);
                        comando.Parameters.AddWithValue("idSala", idSala);
                        comando.Parameters.AddWithValue("fechaR", Fecha);
                        comando.Parameters.AddWithValue("duracion", Duracion);
                        comando.Parameters.AddWithValue("linkR", Link);
                        comando.Parameters.AddWithValue("idReunion", idR);
                        comando.ExecuteNonQuery();
                        Label2.Text = "Reunion Actualizada con exito";
                        con.Close();
                    }
                    else
                    {
                        Label2.Text = "Formato de Link no valida ";
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


        protected void Button7_Click(object sender, EventArgs e)
        {
            //Eliminar
            String queryE = "delete from Reunion where idReunion = ?";
            OdbcConnection conE = new ConexionBD().conexion;
            OdbcCommand comandoE = new OdbcCommand(queryE, conE);
            comandoE.Parameters.AddWithValue("idReunion", Session["Reu"].ToString());
            comandoE.ExecuteNonQuery();
            conE.Close();
            Response.Redirect("MisSalasU");
        }
    }
}