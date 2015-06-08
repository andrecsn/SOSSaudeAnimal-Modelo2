using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class ListarVeterinaria : Model.Shared.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.gridVeterinaria.DataSource = contexto.veterinaria.Select(x => x).ToList();
                this.gridVeterinaria.DataBind();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            string parametro = txtNome.Text;

            if (parametro == "")
            {
                this.gridVeterinaria.DataSource = contexto.veterinaria.Select(x => x).ToList();
                this.gridVeterinaria.DataBind();
            }
            else
            {
                this.gridVeterinaria.DataSource = contexto.veterinaria.Where(x => x.nm_veterinaria.Contains (parametro)).ToList();
                this.gridVeterinaria.DataBind();
            }
        }


        protected void gridVeterinaria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            string cd_veterinaria = gridVeterinaria.DataKeys[index]["cd_veterinaria"].ToString();
            HttpContext.Current.Items["cd_veterinaria"] = cd_veterinaria;

            if (e.CommandName == "Select")
            {
                
                
                //Enviando ID para edição
                HttpContext.Current.Session["alterar"] = "Alterar";
                Server.Transfer("cadastroVeterinaria.aspx");
            }

            if (e.CommandName == "Delete")
            {
                //Enviando ID para exclusão
                HttpContext.Current.Session["excluir"] = "Excluir";
                Server.Transfer("cadastroVeterinaria.aspx");
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("cadastroVeterinaria.aspx");
        }
    }
}