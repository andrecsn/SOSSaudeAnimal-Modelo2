using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class teste2 : Model.Shared.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();
        }
    }
}