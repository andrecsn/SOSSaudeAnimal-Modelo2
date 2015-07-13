﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class ListarFuncionario : Business.Funcionario_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();
            verificaPerfil(this.Page.ToString());

            if (!this.IsPostBack)
            {
                listarGrid();
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
            listarGrid();
        }

        protected void listarGrid()
        {
            string parametro = txtNome.Text;

            if (parametro == "")
            {
                this.gridFuncionario.DataSource = contexto.funcionario.Select(x => x).ToList();
                this.gridFuncionario.DataBind();
            }
            else
            {
                this.gridFuncionario.DataSource = contexto.funcionario.Where(x => x.nm_funcionario.Contains(parametro)).ToList();
                this.gridFuncionario.DataBind();
            }
        }

        protected void gridFuncionario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string cd_funcionario = HttpContext.Current.Session["cd_funcionario"].ToString();
                detalheModal(cd_funcionario);
                modal("#modalExcluir", "show");
            }
            else
            {
                int index = int.Parse((string)e.CommandArgument);
                string cd_funcionario = gridFuncionario.DataKeys[index]["cd_funcionario"].ToString();
                HttpContext.Current.Session["cd_funcionario"] = cd_funcionario;

                if (e.CommandName == "Select")
                {
                    //Enviando ID para edição
                    HttpContext.Current.Session["alterar"] = "Alterar";
                    Response.Redirect("CadastroFuncionario.aspx");
                }
            }
        }

        public string cssGrid(string tipo)
        {
            string retorno = "";

            if (tipo == "Administrador")
                retorno = "label label-success";
            else if (tipo == "Veterinária")
                retorno = "label label-primary";
            else if (tipo == "Atendente")
                retorno = "label label-default";

            return retorno;
        }

        protected void detalheModal(string cd_funcionario)
        {
            int cd_funcionario2 = Convert.ToInt32(cd_funcionario);
            Models.funcionario detalheFuncionario = contexto.funcionario.First(x => x.cd_funcionario == cd_funcionario2);

            hiddenCodigo.Value = detalheFuncionario.cd_funcionario.ToString();
            lblNomeModal.Text = detalheFuncionario.nm_funcionario.ToString();
            HttpContext.Current.Session["cd_funcionario"] = cd_funcionario2;
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            int index = row.RowIndex;
            string cd_funcionario = gridFuncionario.DataKeys[index]["cd_funcionario"].ToString();
            HttpContext.Current.Session["cd_funcionario"] = cd_funcionario;
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(HttpContext.Current.Session["cd_funcionario"]);

                excluirFuncionario(codigo);
                listarGrid();
                modal("#modalExcluir", "hide");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("cadastroFuncionario.aspx");
        }
    }
}