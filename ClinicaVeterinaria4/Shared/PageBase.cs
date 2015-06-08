using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Model.Shared
{
    public class PageBase : System.Web.UI.Page
    {
        protected Model.Shared.Contexto contexto;
        protected override void OnLoad(EventArgs e)
        {
            contexto = new Model.Shared.Contexto();
            base.OnLoad(e);
        }
        protected override void OnUnload(EventArgs e)
        {
            contexto.Dispose();
            base.OnUnload(e);
        }
    }
}
