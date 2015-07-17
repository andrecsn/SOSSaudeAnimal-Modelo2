using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Presentation
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("cd_usuario");
            Session.Remove("usuario");
            Session.Remove("tipo");
            Server.Transfer("~/Presentation/login.aspx");
        }
    }
}