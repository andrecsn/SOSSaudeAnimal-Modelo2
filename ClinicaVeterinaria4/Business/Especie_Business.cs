using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Business
{
    public class Especie_Business : Model.Shared.PageBase
    {
        protected void cadastrarEspecie(string nome, string status)
        {
            Models.especie especie = new Models.especie()
                {
                    nm_especie = nome,
                    st_especie = status
                };
            contexto.especie.Add(especie);
            contexto.SaveChanges();
        }

        protected void editarEspecie(int codigo, string nome, string status)
        {
            Models.especie especie = contexto.especie.First(x => x.cod_especie == codigo);

            especie.nm_especie = nome;
            especie.st_especie = status;

            contexto.SaveChanges();
        }

        protected void excluirEspecie(int codigo)
        {
            Models.especie especie = contexto.especie.First(x => x.cod_especie == codigo);

            especie.st_especie = "Inativa";
            contexto.SaveChanges();
        }
    }
}