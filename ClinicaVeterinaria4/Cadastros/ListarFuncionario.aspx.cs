using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class ListarFuncionario : Model.Shared.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();

            if (!this.IsPostBack)
            {
                this.gridFuncionario.DataSource = contexto.funcionario.Select(x => x).ToList();
                this.gridFuncionario.DataBind();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            string parametro = txtNome.Text;

            if (parametro == "")
            {
                this.gridFuncionario.DataSource = contexto.funcionario.Select(x => x).ToList();
                this.gridFuncionario.DataBind();
            }
            else
            {
                this.gridFuncionario.DataSource = contexto.funcionario.Where(x => x.nm_funcionario.Contains(parametro)).ToList();
                this.gridFuncionario.DataBind();
            }
        }


        protected void gridFuncionario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            string cd_funcionario = gridFuncionario.DataKeys[index]["cd_funcionario"].ToString();
            HttpContext.Current.Items["cd_funcionario"] = cd_funcionario;

            if (e.CommandName == "Select")
            {
                //Enviando ID para edição
                HttpContext.Current.Session["alterar"] = "Alterar";
                Server.Transfer("cadastroFuncionario.aspx");
            }

            if (e.CommandName == "Delete")
            {
                //Enviando ID para exclusão
                HttpContext.Current.Session["excluir"] = "Excluir";
                Server.Transfer("cadastroFuncionario.aspx");
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("cadastroFuncionario.aspx");
        }
    }
}