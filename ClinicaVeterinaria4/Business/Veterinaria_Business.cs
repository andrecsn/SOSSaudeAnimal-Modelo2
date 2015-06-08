using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Business
{
    public class Veterinaria_Business : Model.Shared.PageBase
    {
        protected void cadastrarVeterinaria(string nome, string cpf, string telefone, string celular, string email, string endereco, string bairro, string cep, string cidade, string estado)
        {
            Models.veterinaria veterinaria = new Models.veterinaria()
            {
                nm_veterinaria = nome,
                cpf = cpf,
                telefone = telefone,
                celular = celular,
                email = email,
                endereco = endereco,
                bairro = bairro,
                cep = cep,
                cidade = cidade,
                estado = estado
            };
            contexto.veterinaria.Add(veterinaria);
            contexto.SaveChanges();
            Response.Redirect("listarVeterinaria.aspx");
        }

        protected void editarVeterinaria(int codigo, string nome, string cpf, string telefone, string celular, string email, string endereco, string bairro, string cep, string cidade, string estado)
        {
            Models.veterinaria veterinaria = contexto.veterinaria.First(x => x.cd_veterinaria == codigo);

            veterinaria.nm_veterinaria = nome;
            veterinaria.cpf = cpf;
            veterinaria.telefone = telefone;
            veterinaria.celular = celular;
            veterinaria.email = email;
            veterinaria.endereco = endereco;
            veterinaria.bairro = bairro;
            veterinaria.cep = cep;
            veterinaria.cidade = cidade;
            veterinaria.estado = estado;

            contexto.SaveChanges();
            Response.Redirect("listarVeterinaria.aspx");
        }

        protected void excluirVeterinaria(int codigo)
        {
            Models.veterinaria veterinaria = contexto.veterinaria.First(x => x.cd_veterinaria == codigo);

            contexto.veterinaria.Remove(veterinaria);
            contexto.SaveChanges();
            Response.Redirect("listarVeterinaria.aspx");
        }
    }
}