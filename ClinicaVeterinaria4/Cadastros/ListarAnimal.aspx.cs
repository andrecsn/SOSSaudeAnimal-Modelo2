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
            string animal = txtAnimal.Text;
            string responsavel = txtResponsavel.Text;

            if (animal == "" & responsavel == "")
            {
                this.gridAnimal.DataSource = contexto.animal.Select(x => x).ToList();
                this.gridAnimal.DataBind();
            }
            else
            {
                this.gridAnimal.DataSource = contexto.animal.Where(x => x.nm_animal.Contains(animal) & x.responsavel.nm_responsavel.Contains(responsavel)).ToList();
                this.gridAnimal.DataBind();
            }
        }

        protected void gridAnimal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            string cd_animal = gridAnimal.DataKeys[index]["cd_animal"].ToString();
            HttpContext.Current.Items["cd_animal"] = cd_animal;

            string cd_responsavel = gridAnimal.DataKeys[index]["cd_responsavel"].ToString();
            HttpContext.Current.Items["cd_responsavel"] = cd_responsavel;

            if (e.CommandName == "Select")
            {
                //Enviando ID para edição
                HttpContext.Current.Session["alterar"] = "Alterar";
                Server.Transfer("cadastroAnimal_Novo.aspx");
            }

            if (e.CommandName == "Delete")
            {
                //Enviando ID para exclusão
                HttpContext.Current.Session["excluir"] = "Excluir";
                Server.Transfer("cadastroAnimal_Novo.aspx");
            }

            if (e.CommandName == "Edit")
            {
                //Enviando ID para edição
                HttpContext.Current.Session["novo"] = "NovoAnimal";
                Server.Transfer("cadastroAnimal_Novo.aspx");
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("CadastroAnimal_Responsavel.aspx");
        }
    }
}