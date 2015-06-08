using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria
{
    public partial class cadastroVeterinaria : Business.Veterinaria_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cd_veterinaria = HttpContext.Current.Items["cd_veterinaria"];
            var cmdAlterar = HttpContext.Current.Session["alterar"];
            var cmdExcluir = HttpContext.Current.Session["excluir"];

            if (cmdAlterar == "Alterar" && cd_veterinaria != null)
                exibirEditarVeterinaria(Convert.ToInt32(cd_veterinaria));

            if (cmdExcluir == "Excluir" && cd_veterinaria != null)
                exibirExcluirVeterinaria(Convert.ToInt32(cd_veterinaria));
        }

        public void exibirExcluirVeterinaria(int codigo)
        {
            if (codigo != 0)
            {
                lblCodigo.Text = codigo.ToString();
                Models.veterinaria veterinaria = contexto.veterinaria.First(x => x.cd_veterinaria == codigo);

                lblNome.Text = veterinaria.nm_veterinaria;
                lblCPF.Text = veterinaria.cpf;
                lblTelefone.Text = veterinaria.telefone;
                lblCelular.Text = veterinaria.celular;
                lblEmail.Text = veterinaria.email;
                lblEndereco.Text = veterinaria.endereco;
                lblBairro.Text = veterinaria.bairro;
                lblCEP.Text = veterinaria.cep;
                lblCidade.Text = veterinaria.cidade;
                lblEstado.Text = veterinaria.estado;

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

                btnExcluir.Visible = true;
                btnCadastrar.Visible = false;
                btnAlterar.Visible = false;

                lblTitulo.Text = "Remover Veterinária";

                Session.Remove("excluir");
                Session.Remove("alterar");
            }
        }

        public void exibirEditarVeterinaria(int codigo)
        {
            lblCodigo.Text = codigo.ToString();
            Models.veterinaria veterinaria = contexto.veterinaria.First(x => x.cd_veterinaria == codigo);

            txtNome.Text = veterinaria.nm_veterinaria;
            txtCPF.Text = veterinaria.cpf;
            txtTelefone.Text = veterinaria.telefone;
            txtCelular.Text = veterinaria.celular;
            txtEmail.Text = veterinaria.email;
            txtEndereco.Text = veterinaria.endereco;
            txtBairro.Text = veterinaria.bairro;
            txtCEP.Text = veterinaria.cep;
            txtCidade.Text = veterinaria.cidade;
            cboEstado.SelectedValue = veterinaria.estado;

            btnAlterar.Visible = true;
            btnCadastrar.Visible = false;
            btnExcluir.Visible = false;

            lblTitulo.Text = "Alterar Veterinária";
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

                cadastrarVeterinaria(nome, cpf, telefone, celular, email, endereco, bairro, cep, cidade, estado);
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

                editarVeterinaria(codigo, nome, cpf, telefone, celular, email, endereco, bairro, cep, cidade, estado);
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

                excluirVeterinaria(codigo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnVoltar_click(object sender, EventArgs e)
        {
            Server.Transfer("listarVeterinaria.aspx");
        }
    }
}