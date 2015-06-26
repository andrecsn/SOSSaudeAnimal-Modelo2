using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Business
{
    public class Vacina_Business : Model.Shared.PageBase
    {
        protected void cadastrarVacina(string nome, string status, double valor)
        {
            Models.vacina vacina = new Models.vacina()
            {
                nm_vacina = nome,
                st_vacina = status,
                valor = valor
            };
            contexto.vacina.Add(vacina);
            contexto.SaveChanges();
            Response.Redirect("ListarVacina.aspx");
        }

        protected void editarVacina(int codigo, string nome, string status, double valor)
        {
            Models.vacina vacina = contexto.vacina.First(x => x.cd_vacina == codigo);

            vacina.nm_vacina = nome;
            vacina.valor = valor;
            vacina.st_vacina = status;

            contexto.SaveChanges();
            Response.Redirect("ListarVacina.aspx");
        }

        protected void excluirVacina(int codigo)
        {
            Models.vacina vacina = contexto.vacina.First(x => x.cd_vacina == codigo);

            contexto.vacina.Remove(vacina);
            contexto.SaveChanges();
            Response.Redirect("ListarVacina.aspx");
        }
    }
}