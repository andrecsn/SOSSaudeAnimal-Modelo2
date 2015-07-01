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
            autenticarUsuario();

            var cd_Vacina = HttpContext.Current.Items["cd_vacina"];
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtVacina.Text;
                string status = listStatus.Text;
                double valor = Convert.ToDouble(txtValor.Text);

                cadastrarVacina(nome, status, valor);
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