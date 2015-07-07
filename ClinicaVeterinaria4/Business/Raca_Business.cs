using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Business
{
    public class Raca_Business : Model.Shared.PageBase
    {
        protected void cadastrarRaca(string nm_raca, string st_raca)
        {
            Models.raca raca = new Models.raca()
                {
                    nm_raca = nm_raca,
                    st_raca = st_raca
                };

            contexto.raca.Add(raca);
            contexto.SaveChanges();
        }

        protected void editarRaca(int codigo, string nm_raca, string st_raca)
        {
            Models.raca raca = contexto.raca.First(x => x.cd_raca == codigo);

            raca.nm_raca = nm_raca;
            raca.st_raca = st_raca;

            contexto.SaveChanges();
        }

        protected void excluirRaca(int codigo)
        {
            Models.raca raca = contexto.raca.First(x => x.cd_raca == codigo);

            raca.st_raca = "Inativa";
            contexto.SaveChanges();
        }
    }
}