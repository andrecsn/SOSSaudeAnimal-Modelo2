using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Business
{
    public class Animal_Business : Model.Shared.PageBase
    {
        protected void cadastrarAnimal(string nome, string cor, string peso, DateTime dt_nascimento, string sexo, int responsavel, int raca, int especie, string inf_animal, string foto)
        {
            Models.animal animal = new Models.animal()
            {
                nm_animal = nome,
                cor = cor,
                peso = peso,
                dt_nascimento = dt_nascimento,
                sexo = sexo,
                cd_responsavel = responsavel,
                cd_raca = raca,
                cd_especie = especie,
                inf_animal = inf_animal,
                foto = foto
            };
            contexto.animal.Add(animal);
            contexto.SaveChanges();
            Response.Redirect("cadastroAnimal.aspx");
        }

        protected void editarAnimal(int codigo, string nome, string cor, string peso, DateTime dt_nascimento, string sexo, int responsavel, int raca, int especie, string inf_animal, string foto)
        {
            Models.animal animal = contexto.animal.First(x => x.cd_animal == codigo);

            animal.nm_animal = nome;
            animal.cor = cor;
            animal.peso = peso;
            animal.dt_nascimento = dt_nascimento;
            animal.sexo = sexo;
            animal.cd_responsavel = responsavel;
            animal.cd_raca = raca;
            animal.cd_especie = especie;
            animal.inf_animal = inf_animal;
            animal.foto = foto;

            contexto.SaveChanges();
            Response.Redirect("ListarAnimal.aspx");
        }

        protected void excluirAnimal(int codigo)
        {
            Models.animal animal = contexto.animal.First(x => x.cd_animal == codigo);

            contexto.animal.Remove(animal);
            contexto.SaveChanges();
            Response.Redirect("ListarEspecie.aspx");
        }
    }
}