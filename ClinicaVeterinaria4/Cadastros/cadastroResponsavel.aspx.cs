using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria
{
    public partial class cadastroResponsavel : Business.Responsavel_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cd_responsavel = HttpContext.Current.Items["cd_responsavel"];
            var cmdAlterar = HttpContext.Current.Session["alterar"];
            var cmdExcluir = HttpContext.Current.Session["excluir"];

            if (cmdAlterar == "Alterar" && cd_responsavel != null)
                EditarVeterinaria(Convert.ToInt32(cd_responsavel));

            if (cmdExcluir == "Excluir" && cd_responsavel != null)
                excluirVeterinaria(Convert.ToInt32(cd_responsavel));
        }

        public void excluirVeterinaria(int codigo)
        {
            if (codigo != 0)
            {
                lblCodigo.Text = codigo.ToString();
                Models.responsavel responsavel = contexto.responsavel.First(x => x.cd_responsavel == codigo);

                lblNome.Text = responsavel.nm_responsavel;
                lblCPF.Text = responsavel.CPF;
                lblTelefone.Text = responsavel.telefone;
                lblCelular.Text = responsavel.celular;
                lblEmail.Text = responsavel.email;
                lblEndereco.Text = responsavel.endereco;
                lblBairro.Text = responsavel.bairro;
                lblCidade.Text = responsavel.cidade;
                lblEstado.Text = responsavel.estado;

                lblNome.Visible = true;
                lblCPF.Visible = true;
                lblTelefone.Visible = true;
                lblCelular.Visible = true;
                lblEmail.Visible = true;
                lblEndereco.Visible = true;
                lblBairro.Visible = true;
                lblCidade.Visible = true;
                lblEstado.Visible = true;

                txtNome.Visible = false;
                txtCPF.Visible = false;
                txtTelefone.Visible = false;
                txtCelular.Visible = false;
                txtEmail.Visible = false;
                txtEndereco.Visible = false;
                txtBairro.Visible = false;
                txtCidade.Visible = false;
                cboEstado.Visible = false;

                btnExcluir.Visible = true;
                btnCadastrar.Visible = false;
                btnAlterar.Visible = false;

                lblTitulo.Text = "Remover Responsável";

                Session.Remove("excluir");
                Session.Remove("alterar");
            }
        }

        public void EditarVeterinaria(int codigo)
        {
            lblCodigo.Text = codigo.ToString();
            Models.responsavel responsavel = contexto.responsavel.First(x => x.cd_responsavel == codigo);

            txtNome.Text = responsavel.nm_responsavel;
            txtCPF.Text = responsavel.CPF;
            txtTelefone.Text = responsavel.telefone;
            txtCelular.Text = responsavel.celular;
            txtEmail.Text = responsavel.email;
            txtEndereco.Text = responsavel.endereco;
            txtBairro.Text = responsavel.bairro;
            txtCidade.Text = responsavel.cidade;
            cboEstado.SelectedValue = responsavel.estado;

            btnAlterar.Visible = true;
            btnCadastrar.Visible = false;
            btnExcluir.Visible = false;

            lblTitulo.Text = "Alterar Responsável";
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
                string cidade = txtCidade.Text;
                string estado = cboEstado.Text;

                cadastrarResponsavel(nome, cpf, telefone, celular, email, endereco, bairro, cidade, estado);
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
                string cidade = txtCidade.Text;
                string estado = cboEstado.Text;

                editarResponsavel(codigo, nome, cpf, telefone, celular, email, endereco, bairro, cidade, estado);
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

                excluirResponsavel(codigo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnVoltar_click(object sender, EventArgs e)
        {
            Server.Transfer("listarResponsavel.aspx");
        }

    }
}