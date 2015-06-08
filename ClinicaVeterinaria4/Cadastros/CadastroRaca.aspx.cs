using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class raca : Business.Raca_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cd_raca = HttpContext.Current.Items["cd_raca"];
            var cmdAlterar = HttpContext.Current.Session["alterar"];
            var cmdExcluir = HttpContext.Current.Session["excluir"];

            if (cmdAlterar == "Alterar" && cd_raca != null)
                EditarRaca(Convert.ToInt32(cd_raca));

            if (cmdExcluir == "Excluir" && cd_raca != null)
                excluirRaca(Convert.ToInt32(cd_raca));
        }

        public void excluirRaca(int codigo)
        {
            if (codigo != 0)
            {
                lblCodigo.Text = codigo.ToString();
                Models.raca raca = contexto.raca.First(x => x.cd_raca == codigo);

                lblRaca.Text = raca.nm_raca;
                lblStatus.Text = raca.st_raca;

                lblRaca.Visible = true;
                lblStatus.Visible = true;

                txtRaca.Visible = false;
                listStatus.Visible = false;

                btnExcluir.Visible = true;
                btnCadastrar.Visible = false;
                btnAlterar.Visible = false;

                lblTitulo.Text = "Remover Raça";

                Session.Remove("excluir");
                Session.Remove("alterar");
            }
        }

        public void EditarRaca(int codigo)
        {
            lblCodigo.Text = codigo.ToString();
            Models.raca raca = contexto.raca.First(x => x.cd_raca == codigo);

            txtRaca.Text = raca.nm_raca;
            listStatus.Text = raca.st_raca;

            btnAlterar.Visible = true;
            btnCadastrar.Visible = false;
            btnExcluir.Visible = false;

            lblTitulo.Text = "Alterar Raça";
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtRaca.Text;
                string status = listStatus.Text;

                cadastrarRaca(nome, status);
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
                string nome = txtRaca.Text;
                string status = listStatus.Text;

                editarRaca(codigo, nome, status);
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

                excluirRaca(codigo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnVoltar_click(object sender, EventArgs e)
        {
            Server.Transfer("ListarRaca.aspx");
        }
    }
}