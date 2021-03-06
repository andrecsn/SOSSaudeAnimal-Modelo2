﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Presentation
{
    public partial class ListarVacina : Business.Vacina_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();
            verificaPerfil(this.Page.ToString());

            if (!this.IsPostBack)
            {
                listarGridVacina();
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
            listarGridVacina();
        }

        private void listarGridVacina()
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
            if (e.CommandName == "Deletar")
            {
                string cd_vacina = HttpContext.Current.Session["cd_vacina"].ToString();
                detalheModal(cd_vacina);
                modal("#modalExcluir", "show");
            }
            else
            {
                int index = int.Parse((string)e.CommandArgument);
                string cd_vacina = gridVacina.DataKeys[index]["cd_vacina"].ToString();
                HttpContext.Current.Items["cd_vacina"] = cd_vacina;

                if (e.CommandName == "Select")
                {
                    detalheModal(cd_vacina);
                    btnAlterar.Visible = true;
                    btnCadastrar.Visible = false;
                    lblTituloModal.Text = "Alterar Vacina";
                    modal("#modalAlterarIncluir", "show");
                }
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

        protected void detalheModal(string cd_vacina)
        {
            int cd_vacina2 = Convert.ToInt32(cd_vacina);
            Models.vacina detalheVacina = contexto.vacina.First(x => x.cd_vacina == cd_vacina2);

            hiddenCodigo.Value = detalheVacina.cd_vacina.ToString();
            lblNomeModal.Text = detalheVacina.nm_vacina.ToString();
            txtNomeModal.Text = detalheVacina.nm_vacina.ToString();
            txtValorModal.Text = detalheVacina.valor.ToString();
            HttpContext.Current.Session["cd_vacina"] = cd_vacina2;
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
            string cd_vacina = gridVacina.DataKeys[index]["cd_vacina"].ToString();
            HttpContext.Current.Session["cd_vacina"] = cd_vacina;
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                string nm_vacina = txtNomeModal.Text.ToString();
                double valor = Convert.ToDouble(txtValorModal.Text);

                cadastrarVacina(nm_vacina, "Ativo", valor);
                listarGridVacina();
                modal("#modalAlterarincluir", "hide");
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
                int codigo = Convert.ToInt32(HttpContext.Current.Session["cd_vacina"]);
                string nm_vacina = txtNomeModal.Text.ToString();
                double valor = Convert.ToDouble(txtValorModal.Text);

                editarVacina(codigo, nm_vacina, "Ativo", valor);
                listarGridVacina();
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
                int codigo = Convert.ToInt32(HttpContext.Current.Session["cd_vacina"]);

                excluirVacina(codigo);
                listarGridVacina();
                modal("#modalExcluir", "hide");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}