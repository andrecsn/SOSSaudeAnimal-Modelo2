using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class especie : Business.Especie_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();

            var cd_especie = HttpContext.Current.Items["cod_especie"];
            var cmdAlterar = HttpContext.Current.Session["alterar"];
            var cmdExcluir = HttpContext.Current.Session["excluir"];

            if (cmdAlterar == "Alterar" && cd_especie != null)
                EditarRaca(Convert.ToInt32(cd_especie));

            if (cmdExcluir == "Excluir" && cd_especie != null)
                excluirRaca(Convert.ToInt32(cd_especie));
        }

        public void excluirRaca(int codigo)
        {
            if (codigo != 0)
            {
                lblCodigo.Text = codigo.ToString();
                Models.especie especie = contexto.especie.First(x => x.cod_especie == codigo);

                lblEspecie.Text = especie.nm_especie;
                lblStatus.Text = especie.st_especie;

                lblEspecie.Visible = true;
                lblStatus.Visible = true;

                txtEspecie.Visible = false;
                listStatus.Visible = false;

                btnExcluir.Visible = true;
                btnCadastrar.Visible = false;
                btnAlterar.Visible = false;

                lblTitulo.Text = "Remover Espécie";

                Session.Remove("excluir");
                Session.Remove("alterar");
            }
        }

        public void EditarRaca(int codigo)
        {
            lblCodigo.Text = codigo.ToString();
            Models.especie especie = contexto.especie.First(x => x.cod_especie == codigo);

            txtEspecie.Text = especie.nm_especie;
            listStatus.Text = especie.st_especie;

            btnAlterar.Visible = true;
            btnCadastrar.Visible = false;
            btnExcluir.Visible = false;

            lblTitulo.Text = "Alterar Espécie";
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtEspecie.Text;
                string status = listStatus.SelectedValue;

                cadastrarEspecie(nome, status);
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
                string nome = txtEspecie.Text;
                string status = listStatus.SelectedValue;

                editarEspecie(codigo, nome, status);

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

                excluirEspecie(codigo);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnVoltar_click(object sender, EventArgs e)
        {
            Server.Transfer("ListarEspecie.aspx");
        }
    }
}