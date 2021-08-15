using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Club_de_Lectura
{
    public partial class InicioAdmin1 : System.Web.UI.Page
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("LoginAdmin.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("CRUDUsuariosAdmin.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("CRUDSalasAdmin.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("CRUDLibrosAdmin.aspx");

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("CRUDTemasAdmin.aspx");

        }

    }
}