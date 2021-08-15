using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Club_de_Lectura
{
    public partial class InicioUsuario1 : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("UsuarioLogin.aspx");
        } 

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Administrar
            Response.Redirect("PerfilU.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Unirse a Sala
            Response.Redirect("UnirseSalaU.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Crear Sala
            Response.Redirect("CrearSalaU.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //Mis Salas
            Response.Redirect("MisSalasU.aspx");
        }
    }
}