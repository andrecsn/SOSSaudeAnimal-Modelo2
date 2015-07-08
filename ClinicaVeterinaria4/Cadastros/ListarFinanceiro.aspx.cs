using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class ListarFinanceiro : Business.Funcionario_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                listarGrid("");
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            listarGrid(txtNome.Text);
        }

        protected void listarGrid(string nome)
        {
            var dados = from a in contexto.funcionario
                        where a.nm_funcionario.Contains(nome) & a.tipo != "Atendente"
                        select new
                        {
                            cd_funcionario = a.cd_funcionario,
                            nm_funcionario = a.nm_funcionario,
                            cpf = a.cpf,
                            telefone = a.telefone,
                            celular = a.celular,
                            tipo = a.tipo
                        };
            this.gridFuncionario.DataSource = dados.ToList();
            this.gridFuncionario.DataBind();
        }

        protected void gridFuncionario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse((string)e.CommandArgument);
                string cd_funcionario = gridFuncionario.DataKeys[index]["cd_funcionario"].ToString();
                HttpContext.Current.Session["cd_funcionario"] = cd_funcionario;

                Response.Redirect("RelatorioFinanceiro.aspx");
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
    }
}