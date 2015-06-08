using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class vacina : Business.Vacina_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cd_Vacina = HttpContext.Current.Items["cd_vacina"];
            var cmdAlterar = HttpContext.Current.Session["alterar"];
            var cmdExcluir = HttpContext.Current.Session["excluir"];

            if (cmdAlterar == "Alterar" && cd_Vacina != null)
                exibirEditarVacina(Convert.ToInt32(cd_Vacina));

            if (cmdExcluir == "Excluir" && cd_Vacina != null)
                exibirExcluirVacina(Convert.ToInt32(cd_Vacina));
        }

        public void exibirExcluirVacina(int codigo)
        {
            if (codigo != 0)
            {
                lblCodigo.Text = codigo.ToString();
                Models.vacina vacina = contexto.vacina.First(x => x.cd_vacina == codigo);

                lblVacina.Text = vacina.nm_vacina;
                lblStatus.Text = vacina.st_vacina;

                lblVacina.Visible = true;
                lblStatus.Visible = true;

                txtVacina.Visible = false;
                listStatus.Visible = false;

                btnExcluir.Visible = true;
                btnCadastrar.Visible = false;
                btnAlterar.Visible = false;

                lblTitulo.Text = "Remover Vacina";

                Session.Remove("excluir");
                Session.Remove("alterar");
            }
        }

        public void exibirEditarVacina(int codigo)
        {
            lblCodigo.Text = codigo.ToString();
            Models.vacina vacina = contexto.vacina.First(x => x.cd_vacina == codigo);

            txtVacina.Text = vacina.nm_vacina;
            listStatus.Text = vacina.st_vacina;

            btnAlterar.Visible = true;
            btnCadastrar.Visible = false;
            btnExcluir.Visible = false;

            lblTitulo.Text = "Alterar Vacina";
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtVacina.Text;
                string status = listStatus.Text;

                cadastrarVacina(nome, status);
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
                string nome = txtVacina.Text;
                string status = listStatus.Text;

                editarVacina(codigo, nome, status);
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

                excluirVacina(codigo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnVoltar_click(object sender, EventArgs e)
        {
            Server.Transfer("ListarVacina.aspx");
        }

    }
}