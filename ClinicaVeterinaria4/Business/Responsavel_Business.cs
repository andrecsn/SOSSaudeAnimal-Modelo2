using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Business
{
    public class Responsavel_Business : Model.Shared.PageBase
    {
        protected void cadastrarResponsavel(string nome, string cpf, string telefone, string celular, string email, string endereco, string bairro, string cidade, string estado)
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
            Response.Redirect("cadastroResponsavel.aspx");
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
            Response.Redirect("listarResponsavel.aspx");
        }

        protected void excluirResponsavel(int codigo)
        {
            Models.responsavel responsavel = contexto.responsavel.First(x => x.cd_responsavel == codigo);

            contexto.responsavel.Remove(responsavel);
            contexto.SaveChanges();
            Response.Redirect("listarVeterinaria.aspx");
        }
    }
}