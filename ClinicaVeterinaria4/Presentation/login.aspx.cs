using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Presentation
{
    public partial class login : Business.Funcionario_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            string login = txtUsuario.Text;
            string senha = txtSenha.Text;

            verificarUsuario(login, senha);
        }
    }
}