using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Model.Shared
{
    public class PageBase : System.Web.UI.Page
    {
        protected Model.Shared.Contexto contexto;
        protected override void OnLoad(EventArgs e)
        {
            contexto = new Model.Shared.Contexto();
            base.OnLoad(e);
        }
        protected override void OnUnload(EventArgs e)
        {
            contexto.Dispose();
            base.OnUnload(e);
        }

        protected void autenticarUsuario()
        {
            var cd_usuario = HttpContext.Current.Session["cd_usuario"];

            if (cd_usuario == null) Response.Redirect("logout.aspx");
        }

        protected void modal(string modal, string estado)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("$('" + modal + "').modal('" + estado + "');");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);
        }
    }
}
