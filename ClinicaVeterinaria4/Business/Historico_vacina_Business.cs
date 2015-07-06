using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Business
{
    public class Historico_vacina_Business : Model.Shared.PageBase
    {

        protected void cadastrarHistoricoVacina(int animal, int vacina, DateTime data, DateTime vencimento, int cd_funcionario, string pagina)
        {
            Models.historico_vacina historico_vacina = new Models.historico_vacina()
            {
                cd_animal = animal,
                cd_vacina = vacina,
                cd_funcionario = cd_funcionario,
                dt_hist_vacina = data,
                dt_vencimento = vencimento
            };
            contexto.historico_vacina.Add(historico_vacina);
            contexto.SaveChanges();

            //Enviando ID para a página de inserção de novo animal
            HttpContext.Current.Items["cd_animal"] = animal;
            //HttpContext.Current.Items["cd_responsavel"] = historico_vacina;
            //Server.Transfer(pagina);
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

        protected void excluirHistVacina(int vacina, int animal, string pagina)
        {
            Models.historico_vacina historico_vacina = contexto.historico_vacina.First(x => x.cd_hist_vacina == vacina);

            contexto.historico_vacina.Remove(historico_vacina);
            contexto.SaveChanges();

            if (pagina != "")
            {
                //Enviando ID para a página de inserção de novo animal
                HttpContext.Current.Items["cd_animal"] = animal;
                Server.Transfer(pagina);
            }
            
        }
    }
}