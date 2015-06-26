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

            var cd_funcionario = HttpContext.Current.Items["cd_funcionario"];
            var cmdAlterar = HttpContext.Current.Session["alterar"];
            var cmdExcluir = HttpContext.Current.Session["excluir"];

            if (cmdAlterar == "Alterar" && cd_funcionario != null)
                exibirEditarFuncionario(Convert.ToInt32(cd_funcionario));

            if (cmdExcluir == "Excluir" && cd_funcionario != null)
                exibirExcluirFuncionario(Convert.ToInt32(cd_funcionario));
        }

        public void exibirExcluirFuncionario(int codigo)
        {
            if (codigo != 0)
            {
                lblCodigo.Text = codigo.ToString();
                Models.funcionario funcionario = contexto.funcionario.First(x => x.cd_funcionario == codigo);

                lblNome.Text = funcionario.nm_funcionario;
                lblCPF.Text = funcionario.cpf;
                lblTelefone.Text = funcionario.telefone;
                lblCelular.Text = funcionario.celular;
                lblEmail.Text = funcionario.email;
                lblEndereco.Text = funcionario.endereco;
                lblBairro.Text = funcionario.bairro;
                lblCEP.Text = funcionario.cep;
                lblCidade.Text = funcionario.cidade;
                lblEstado.Text = funcionario.estado;
                lblLogin.Text = funcionario.login;
                lblTipo.Text = funcionario.tipo.ToString();

                lblNome.Visible = true;
                lblCPF.Visible = true;
                lblTelefone.Visible = true;
                lblCelular.Visible = true;
                lblEmail.Visible = true;
                lblEndereco.Visible = true;
                lblBairro.Visible = true;
                lblCEP.Visible = true;
                lblCidade.Visible = true;
                lblEstado.Visible = true;
                lblLogin.Visible = true;
                lblTipo.Visible = true;

                txtNome.Visible = false;
                txtCPF.Visible = false;
                txtTelefone.Visible = false;
                txtCelular.Visible = false;
                txtEmail.Visible = false;
                txtEndereco.Visible = false;
                txtBairro.Visible = false;
                txtCEP.Visible = false;
                txtCidade.Visible = false;
                cboEstado.Visible = false;
                txtLogin.Visible = false;
                txtSenha.Visible = false;
                cboTipo.Visible = false;

                btnExcluir.Visible = true;
                btnCadastrar.Visible = false;
                btnAlterar.Visible = false;

                lblTitulo.Text = "Remover Funcionário";

                Session.Remove("excluir");
                Session.Remove("alterar");
            }
        }

        public void exibirEditarFuncionario(int codigo)
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

            lblSenhaTitulo.Visible = false;
            txtSenha.Visible = false;

            btnAlterar.Visible = true;
            btnCadastrar.Visible = false;
            btnExcluir.Visible = false;

            lblTitulo.Text = "Alterar Funcionário";
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
                string estado = cboEstado.Text;
                string login = txtLogin.Text;
                string senha = txtSenha.Text;
                string tipo = cboTipo.Text;

                editarFuncionario(codigo, nome, cpf, telefone, celular, email, endereco, bairro, cep, cidade, estado, login, senha, tipo);
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
                int codigo = Convert.ToInt32(lblCodigo.Text);

                excluirFuncionario(codigo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnVoltar_click(object sender, EventArgs e)
        {
            Server.Transfer("listarFuncionario.aspx");
        }
    }
}