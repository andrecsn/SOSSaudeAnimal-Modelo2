using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class ListarAnimal : Model.Shared.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.gridAnimal.DataSource = contexto.animal.Select(x => x).ToList();
                this.gridAnimal.DataBind();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            string parametro = txtNome.Text;

            if (parametro == "")
            {
                this.gridAnimal.DataSource = contexto.animal.Select(x => x).ToList();
                this.gridAnimal.DataBind();
            }
            else
            {
                this.gridAnimal.DataSource = contexto.vacina.Where(x => x.nm_vacina.Contains(parametro)).ToList();
                this.gridAnimal.DataBind();
            }
        }

        protected void gridAnimal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            string cd_animal = gridAnimal.DataKeys[index]["cd_animal"].ToString();
            HttpContext.Current.Items["cd_animal"] = cd_animal;

            if (e.CommandName == "Select")
            {
                //Enviando ID para edição
                HttpContext.Current.Session["alterar"] = "Alterar";
                Server.Transfer("cadastroAnimal.aspx");
            }

            if (e.CommandName == "Delete")
            {
                //Enviando ID para exclusão
                HttpContext.Current.Session["excluir"] = "Excluir";
                Server.Transfer("cadastroAnimal.aspx");
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("CadastroAnimal.aspx");
        }
    }
}