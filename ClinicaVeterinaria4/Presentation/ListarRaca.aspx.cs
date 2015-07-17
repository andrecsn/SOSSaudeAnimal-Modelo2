using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Presentation
{
    public partial class ListarRaca : Business.Raca_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();
            verificaPerfil(this.Page.ToString());

            if (!this.IsPostBack)
            {
                ListarGrid(txtNome.Text);
            }
        }

        public bool delete()
        {
            string tipo = HttpContext.Current.Session["tipo"].ToString();

            if (tipo == "Administrador")
                return true;
            else
                return false;
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            ListarGrid(txtNome.Text);
        }

        protected void ListarGrid(string parametro)
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
            if (e.CommandName == "Deletar")
            {
                string cd_raca = HttpContext.Current.Session["cd_raca"].ToString();
                detalheModal(cd_raca);
                modal("#modalExcluir", "show");
            }
            else
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

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            int index = row.RowIndex;
            string cd_raca = gridRaca.DataKeys[index]["cd_raca"].ToString();
            HttpContext.Current.Session["cd_raca"] = cd_raca;
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                string nm_raca = txtNomeModal.Text.ToString();

                cadastrarRaca(nm_raca, "Ativo");
                ListarGrid(txtNome.Text);
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
                ListarGrid(txtNome.Text);
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
                ListarGrid(txtNome.Text);
                modal("#modalExcluir", "hide");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}