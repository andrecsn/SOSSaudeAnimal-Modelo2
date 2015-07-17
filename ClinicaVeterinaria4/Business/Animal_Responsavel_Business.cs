using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Business
{
    public class Animal_Responsavel_Business : Model.Shared.PageBase
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
        }

        protected void excluirAnimal(int codigo)
        {
            Models.animal animal = contexto.animal.First(x => x.cd_animal == codigo);

            contexto.animal.Remove(animal);
            contexto.SaveChanges();

            //Enviando ID para a página de inserção de novo animal
            HttpContext.Current.Session["novo"] = "NovoAnimal";
        }

        protected int cadastrarResponsavel(string nome, string cpf, string telefone, string celular, string email, string endereco, string bairro, string cidade, string estado)
        {
            Models.responsavel responsavel = new Models.responsavel()
            {
                nm_responsavel = nome,
                CPF = cpf,
                telefone = telefone,
                celular = celular,
                email = email,
                endereco = endereco,
                bairro = bairro,
                cidade = cidade,
                estado = estado
            };
            contexto.responsavel.Add(responsavel);
            contexto.SaveChanges();

            int idResponsavel = responsavel.cd_responsavel;
            return (idResponsavel);
        }

        protected void editarResponsavel(int codigo, string nome, string cpf, string telefone, string celular, string email, string endereco, string bairro, string cidade, string estado)
        {
            Models.responsavel responsavel = contexto.responsavel.First(x => x.cd_responsavel == codigo);

            responsavel.nm_responsavel = nome;
            responsavel.CPF = cpf;
            responsavel.telefone = telefone;
            responsavel.celular = celular;
            responsavel.email = email;
            responsavel.endereco = endereco;
            responsavel.bairro = bairro;
            responsavel.cidade = cidade;
            responsavel.estado = estado;

            contexto.SaveChanges();
        }

        protected void excluirResponsavel(int codigo)
        {
            Models.responsavel responsavel = contexto.responsavel.First(x => x.cd_responsavel == codigo);

            contexto.responsavel.Remove(responsavel);
            contexto.SaveChanges();
            Response.Redirect("~/Presentation/listarResponsavel.aspx");
        }
    }
}