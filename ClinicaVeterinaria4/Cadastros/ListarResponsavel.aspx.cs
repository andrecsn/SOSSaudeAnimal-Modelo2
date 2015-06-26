using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class listarResponsavel : Model.Shared.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();

            if (!this.IsPostBack)
            {
                this.gridResponsavel.DataSource = contexto.responsavel.Select(x => x).ToList();
                this.gridResponsavel.DataBind();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            string parametro = txtNome.Text;

            if (parametro == "")
            {
                this.gridResponsavel.DataSource = contexto.responsavel.Select(x => x).ToList();
                this.gridResponsavel.DataBind();
            }
            else
            {
                this.gridResponsavel.DataSource = contexto.responsavel.Where(x => x.nm_responsavel.Contains(parametro)).ToList();
                this.gridResponsavel.DataBind();
            }
        }

        protected void gridResponsavel_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            string cd_responsavel = gridResponsavel.DataKeys[index]["cd_responsavel"].ToString();
            HttpContext.Current.Items["cd_responsavel"] = cd_responsavel;

            if (e.CommandName == "Select")
            {
                //Enviando ID para edição
                HttpContext.Current.Session["alterar"] = "Alterar";
                Server.Transfer("cadastroResponsavel.aspx");
            }

            if (e.CommandName == "Delete")
            {
                //Enviando ID para exclusão
                HttpContext.Current.Session["excluir"] = "Excluir";
                Server.Transfer("cadastroResponsavel.aspx");
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("cadastroResponsavel.aspx");
        }
    }
}