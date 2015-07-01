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
            autenticarUsuario();

            var cd_raca = HttpContext.Current.Items["cd_raca"];
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

        protected void btnVoltar_click(object sender, EventArgs e)
        {
            Server.Transfer("ListarRaca.aspx");
        }
    }
}