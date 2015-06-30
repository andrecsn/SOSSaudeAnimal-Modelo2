using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class ListarRaca : Business.Raca_Business
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
            listarGridRaca();
        }

        protected void listarGridRaca()
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

            if (e.CommandName == "New")
            {
                detalheRacaModal(cd_raca);
                modal("#excluirRaca", "show");
            }
        }

        protected void detalheRacaModal(string cd_raca)
        {
            int cd_raca2 = Convert.ToInt32(cd_raca);
            Models.raca detalheRaca = contexto.raca.First(x => x.cd_raca == cd_raca2);

            hiddenCodigo.Value = detalheRaca.cd_raca.ToString();
            lblNomeRaca.Text = detalheRaca.nm_raca.ToString();
            HttpContext.Current.Session["cd_raca"] = cd_raca2;
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("cadastroRaca.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(HttpContext.Current.Session["cd_raca"]);

                excluirRaca(codigo);
                listarGridRaca();
                modal("#excluirRaca", "hide");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}