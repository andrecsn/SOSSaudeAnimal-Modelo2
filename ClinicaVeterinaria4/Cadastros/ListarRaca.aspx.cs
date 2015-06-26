using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class ListarRaca : Model.Shared.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();

            if (!this.IsPostBack)
            {
                this.gridRaca.DataSource = contexto.raca.Select(x => x).ToList();
                this.gridRaca.DataBind();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            string parametro = txtNome.Text;

            if (parametro == "")
            {
                this.gridRaca.DataSource = contexto.raca.Select(x => x).ToList();
                this.gridRaca.DataBind();
            }
            else
            {
                this.gridRaca.DataSource = contexto.raca.Where(x => x.nm_raca.Contains(parametro)).ToList();
                this.gridRaca.DataBind();
            }
        }

        protected void gridRaca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            string cd_raca = gridRaca.DataKeys[index]["cd_raca"].ToString();
            HttpContext.Current.Items["cd_raca"] = cd_raca;

            if (e.CommandName == "Select")
            {
                //Enviando ID para edição
                HttpContext.Current.Session["alterar"] = "Alterar";
                Server.Transfer("cadastroRaca.aspx");
            }

            if (e.CommandName == "Delete")
            {
                //Enviando ID para exclusão
                HttpContext.Current.Session["excluir"] = "Excluir";
                Server.Transfer("cadastroRaca.aspx");
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("cadastroRaca.aspx");
        }
    }
}