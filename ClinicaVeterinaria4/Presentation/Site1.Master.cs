using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Presentation
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFuncionario.Text = HttpContext.Current.Session["usuario"].ToString();
            lblTipo.Text = HttpContext.Current.Session["tipo"].ToString();
        }
    }
}