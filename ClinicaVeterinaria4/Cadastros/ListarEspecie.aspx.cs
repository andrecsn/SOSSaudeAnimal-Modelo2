using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class ListarEspecie : Model.Shared.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();

            if (!this.IsPostBack)
            {
                this.gridEspecie.DataSource = contexto.especie.Select(x => x).ToList();
                this.gridEspecie.DataBind();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            string parametro = txtNome.Text;

            if (parametro == "")
            {
                this.gridEspecie.DataSource = contexto.especie.Select(x => x).ToList();
                this.gridEspecie.DataBind();
            }
            else
            {
                this.gridEspecie.DataSource = contexto.especie.Where(x => x.nm_especie.Contains(parametro)).ToList();
                this.gridEspecie.DataBind();
            }
        }

        protected void gridEspecie_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            string cd_especie = gridEspecie.DataKeys[index]["cod_especie"].ToString();
            HttpContext.Current.Items["cod_especie"] = cd_especie;

            if (e.CommandName == "Select")
            {
                //Enviando ID para edição
                HttpContext.Current.Session["alterar"] = "Alterar";
                Server.Transfer("cadastroEspecie.aspx");
            }

            if (e.CommandName == "Delete")
            {
                //Enviando ID para exclusão
                HttpContext.Current.Session["excluir"] = "Excluir";
                Server.Transfer("cadastroEspecie.aspx");
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("cadastroEspecie.aspx");
        }
    }
}