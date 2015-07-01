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


        protected void btnVoltar_click(object sender, EventArgs e)
        {
            Server.Transfer("ListarEspecie.aspx");
        }
    }
}