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
            verificaPerfil(this.Page.ToString());

            if (!this.IsPostBack)
            {
                listarGrid(txtNome.Text);
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            listarGrid(txtNome.Text);
        }

        protected void listarGrid(string parametro)
        {
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

        public string cssGrid(string tipo)
        {
            if (tipo == "Ativo")
                return "label label-success";
            else if (tipo == "Inativa")
                return "label label-danger";

            return "";
        }

        protected void gridRaca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            string cd_raca = gridRaca.DataKeys[index]["cd_raca"].ToString();
            HttpContext.Current.Items["cd_raca"] = cd_raca;

            if (e.CommandName == "Select")
            {
                detalheModal(cd_raca);
                btnAlterar.Visible = true;
                btnCadastrar.Visible = false;
                lblTituloModal.Text = "Alterar Raça";
                modal("#modalAlterarIncluir", "show");
            }

            if (e.CommandName == "New")
            {
                detalheModal(cd_raca);
                modal("#modalExcluir", "show");
            }
        }

        protected void detalheModal(string cd_raca)
        {
            int cd_raca2 = Convert.ToInt32(cd_raca);
            Models.raca detalheRaca = contexto.raca.First(x => x.cd_raca == cd_raca2);

            hiddenCodigo.Value = detalheRaca.cd_raca.ToString();
            lblNomeModal.Text = detalheRaca.nm_raca.ToString();
            txtNomeModal.Text = detalheRaca.nm_raca.ToString();
            HttpContext.Current.Session["cd_raca"] = cd_raca2;
        }

        protected void btnCadastrarModal_Click(object sender, EventArgs e)
        {
            txtNomeModal.Text = "";
            btnCadastrar.Visible = true;
            btnAlterar.Visible = false;
            lblTituloModal.Text = "Incluir Raça";
            modal("#modalAlterarIncluir", "show");
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                string nm_raca = txtNomeModal.Text.ToString();

                cadastrarRaca(nm_raca, "Ativo");
                listarGrid(txtNome.Text);
                modal("#modalAlterarIncluir", "hide");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(HttpContext.Current.Session["cd_raca"]);
                string nm_raca = txtNomeModal.Text.ToString();

                editarRaca(codigo, nm_raca, "Ativo");
                listarGrid(txtNome.Text);
                modal("#modalAlterarIncluir", "hide");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(HttpContext.Current.Session["cd_raca"]);

                excluirRaca(codigo);
                listarGrid(txtNome.Text);
                modal("#modalExcluir", "hide");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}