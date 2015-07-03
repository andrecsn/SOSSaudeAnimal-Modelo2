using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria
{
    public partial class cadastroVeterinaria : Business.Funcionario_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();

            if (!this.IsPostBack)
            {
                var cd_funcionario = HttpContext.Current.Session["cd_funcionario"];
                var cmdAlterar = HttpContext.Current.Session["alterar"];

                if (cmdAlterar == "Alterar" && cd_funcionario != null)
                    exibirEditarFuncionario(Convert.ToInt32(cd_funcionario));
            }
        }


        protected void exibirEditarFuncionario(int codigo)
        {
            lblCodigo.Text = codigo.ToString();
            Models.funcionario funcionario = contexto.funcionario.First(x => x.cd_funcionario == codigo);

            txtNome.Text = funcionario.nm_funcionario;
            txtCPF.Text = funcionario.cpf;
            txtTelefone.Text = funcionario.telefone;
            txtCelular.Text = funcionario.celular;
            txtEmail.Text = funcionario.email;
            txtEndereco.Text = funcionario.endereco;
            txtBairro.Text = funcionario.bairro;
            txtCEP.Text = funcionario.cep;
            txtCidade.Text = funcionario.cidade;
            cboEstado.SelectedValue = funcionario.estado;
            txtLogin.Text = funcionario.login;
            cboTipo.SelectedValue = funcionario.tipo;

            btnAlterar.Visible = true;
            btnCadastrar.Visible = false;

            lblTitulo.Text = "Alterar Funcionário";
            Session.Remove("alterar");
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                string cpf = txtCPF.Text;
                string telefone = txtTelefone.Text;
                string celular = txtCelular.Text;
                string email = txtEmail.Text;
                string endereco = txtEndereco.Text;
                string bairro = txtBairro.Text;
                string cep = txtCEP.Text;
                string cidade = txtCidade.Text;
                string estado = cboEstado.Text;
                string login = txtLogin.Text;
                string senha = txtSenha.Text;
                string tipo = cboTipo.Text;

                cadastrarFuncionario(nome, cpf, telefone, celular, email, endereco, bairro, cep, cidade, estado, login, senha, tipo);
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
                int codigo = Convert.ToInt32(lblCodigo.Text);
                string nome = txtNome.Text;
                string cpf = txtCPF.Text;
                string telefone = txtTelefone.Text;
                string celular = txtCelular.Text;
                string email = txtEmail.Text;
                string endereco = txtEndereco.Text;
                string bairro = txtBairro.Text;
                string cep = txtCEP.Text;
                string cidade = txtCidade.Text;
                string estado = cboEstado.SelectedValue;
                string login = txtLogin.Text;
                string tipo = cboTipo.SelectedValue;

                editarFuncionario(codigo, nome, cpf, telefone, celular, email, endereco, bairro, cep, cidade, estado, login, tipo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnVoltar_click(object sender, EventArgs e)
        {
            Server.Transfer("listarFuncionario.aspx");

            //Removendo sessões
            Session.Remove("cd_funcionario");
            Session.Remove("alterar");
        }
    }
}