using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Business
{
    public class Historico_vacina_Business : Model.Shared.PageBase
    {

        protected void cadastrarHistoricoVacina(int animal, int vacina, DateTime data, DateTime vencimento)
        {
            Models.historico_vacina historico_vacina = new Models.historico_vacina()
            {
                cd_animal = animal,
                cd_vacina = vacina,
                dt_hist_vacina = data,
                dt_vencimento = vencimento
            };
            contexto.historico_vacina.Add(historico_vacina);
            contexto.SaveChanges();
            //Response.Redirect("cadastrarHistVacina.aspx");
        }

        protected void editarHistVacina(int codigo, int animal, int vacina, DateTime data, DateTime vencimento)
        {
            Models.historico_vacina historico_vacina = contexto.historico_vacina.First(x => x.cd_hist_vacina == codigo);

            historico_vacina.cd_animal = animal;
            historico_vacina.cd_vacina = vacina;
            historico_vacina.dt_hist_vacina = data;
            historico_vacina.dt_vencimento = vencimento;

            contexto.SaveChanges();
            Response.Redirect("ListarHistVacina.aspx");
        }

        protected void excluirHistVacina(int codigo)
        {
            Models.historico_vacina historico_vacina = contexto.historico_vacina.First(x => x.cd_hist_vacina == codigo);

            contexto.historico_vacina.Remove(historico_vacina);
            contexto.SaveChanges();
            Response.Redirect("ListarHistVacina.aspx");
        }
    }
}