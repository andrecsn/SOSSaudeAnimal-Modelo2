using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class ListarVacina : Model.Shared.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.gridVacina.DataSource = contexto.vacina.Select(x => x).ToList();
                this.gridVacina.DataBind();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            string parametro = txtNome.Text;

            if (parametro == "")
            {
                this.gridVacina.DataSource = contexto.vacina.Select(x => x).ToList();
                this.gridVacina.DataBind();
            }
            else
            {
                this.gridVacina.DataSource = contexto.vacina.Where(x => x.nm_vacina.Contains(parametro)).ToList();
                this.gridVacina.DataBind();
            }
        }

        protected void gridVacina_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            string cd_vacina = gridVacina.DataKeys[index]["cd_vacina"].ToString();
            HttpContext.Current.Items["cd_vacina"] = cd_vacina;

            if (e.CommandName == "Select")
            {
                //Enviando ID para edição
                HttpContext.Current.Session["alterar"] = "Alterar";
                Server.Transfer("cadastroVacina.aspx");
            }

            if (e.CommandName == "Delete")
            {
                //Enviando ID para exclusão
                HttpContext.Current.Session["excluir"] = "Excluir";
                Server.Transfer("cadastroVacina.aspx");
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("cadastroVacina.aspx");
        }
    }
}