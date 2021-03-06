﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Presentation
{
    public partial class ListarEspecie : Business.Especie_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();
            verificaPerfil(this.Page.ToString());

            if (!this.IsPostBack)
            {
                ListarGrid();
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
            ListarGrid();
        }

        protected void ListarGrid()
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
            if (e.CommandName == "Deletar")
            {
                string cod_especie = HttpContext.Current.Session["cod_especie"].ToString();
                detalheModal(cod_especie);
                modal("#modalExcluir", "show");
            }
            else
            {
                int index = int.Parse((string)e.CommandArgument);
                string cd_especie = gridEspecie.DataKeys[index]["cod_especie"].ToString();
                HttpContext.Current.Items["cod_especie"] = cd_especie;

                if (e.CommandName == "Select")
                {
                    detalheModal(cd_especie);
                    btnAlterar.Visible = true;
                    btnCadastrar.Visible = false;
                    lblTituloModal.Text = "Alterar Espécie";
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

        protected void detalheModal(string cd_especie)
        {
            int cd_especie2 = Convert.ToInt32(cd_especie);
            Models.especie detalheEspecie = contexto.especie.First(x => x.cod_especie == cd_especie2);

            hiddenCodigo.Value = detalheEspecie.cod_especie.ToString();
            lblNomeModal.Text = detalheEspecie.nm_especie.ToString();
            txtNomeModal.Text = detalheEspecie.nm_especie.ToString();
            HttpContext.Current.Session["cd_especie"] = cd_especie2;
        }

        protected void btnCadastrarModal_Click(object sender, EventArgs e)
        {
            txtNomeModal.Text = "";
            btnCadastrar.Visible = true;
            btnAlterar.Visible = false;
            lblTituloModal.Text = "Incluir Espécie";
            modal("#modalAlterarIncluir", "show");
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            int index = row.RowIndex;
            string cod_especie = gridEspecie.DataKeys[index]["cod_especie"].ToString();
            HttpContext.Current.Session["cod_especie"] = cod_especie;
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                string nm_especie = txtNomeModal.Text.ToString();

                cadastrarEspecie(nm_especie, "Ativo");
                ListarGrid();
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
                int codigo = Convert.ToInt32(HttpContext.Current.Session["cd_especie"]);
                string nm_especie = txtNomeModal.Text.ToString();

                editarEspecie(codigo, nm_especie, "Ativo");
                ListarGrid();
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
                int codigo = Convert.ToInt32(HttpContext.Current.Session["cd_especie"]);

                excluirEspecie(codigo);
                ListarGrid();
                modal("#modalExcluir", "hide");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}