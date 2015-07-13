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

        protected void verificaPerfil(string tela)
        {
            //pegando o perfil do usuário logado
            int cd_usuario = Convert.ToInt32(HttpContext.Current.Session["cd_usuario"]);
            string perfil = HttpContext.Current.Session["tipo"].ToString();

            tela = tela.Replace("ASP.cadastros_", "");
            tela = tela.Replace("_aspx", ".aspx");

            //verificando o perfil e redirecioanndo
            Models.perfil_acesso perfil_acesso = contexto.perfil_acesso.First(x => x.nm_tela == tela);

            if (tela == "listarfinanceiro.aspx" & perfil == "Veterinária")
            {
                HttpContext.Current.Session["cd_funcionario"] = cd_usuario;
                Response.Redirect("RelatorioFinanceiro.aspx");
            }

            if (perfil == "Administrador" & perfil_acesso.perfil_administrador == 0)
                Response.Redirect("semPermissao.aspx");

            if (perfil == "Veterinária" & perfil_acesso.perfil_veterinaria == 0)
                Response.Redirect("semPermissao.aspx");

            if (perfil == "Atendente" & perfil_acesso.perfil_atendente == 0)
                Response.Redirect("semPermissao.aspx");
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
